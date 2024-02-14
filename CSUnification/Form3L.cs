using OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LSystem
{
    public partial class Form3L : Form
    {
        enum MOUSE_MOVE_MODE { Orbit, Move };
        bool _isMouseDown = false;
        MOUSE_MOVE_MODE _mouseMode = MOUSE_MOVE_MODE.Orbit;

        EngineLoop _gameLoop;
        List<Entity> entities;
        StaticShader _shader;
        PolygonMode _polygonMode = PolygonMode.Fill;
        Random _rnd;
        LSystemUnif _lSystem;

        string _leafFileName;
        string _stemFileName;

        public Form3L()
        {
            InitializeComponent();
            _rnd = new Random();
            _lSystem = new LSystemUnif(_rnd);
        }


        private void Form3L_Load(object sender, EventArgs e)
        {
            // ### 초기화 ###
            IniFile.SetFileName("setup.ini");

            _gameLoop = new EngineLoop();
            _shader = new StaticShader();
            entities = new List<Entity>();

            Texture texture = new Texture(EngineLoop.PROJECT_PATH + @"\Res\bricks.jpg");
            TexturedModel texturedModel = new TexturedModel(Loader3d.LoadCube(20, 20), texture);

            Entity ent = new Entity(texturedModel);
            ent.Position = new Vertex3f(0, 0, 0);
            ent.Scaled(20, 20, 0.1f);
            ent.Material = Material.White;
            entities.Add(ent);

            float cx = float.Parse(IniFile.GetPrivateProfileString("camera", "x", "0.0"));
            float cy = float.Parse(IniFile.GetPrivateProfileString("camera", "y", "0.0"));
            float cz = float.Parse(IniFile.GetPrivateProfileString("camera", "z", "0.0"));

            _gameLoop.Camera = new OrbitCamera("", 13, -2, 3, 15);           
            _gameLoop.Camera.Position = new Vertex3f(cx, cy, cz);
            _gameLoop.Camera.CameraYaw = float.Parse(IniFile.GetPrivateProfileString("camera", "yaw", "0.0"));
            _gameLoop.Camera.CameraPitch = float.Parse(IniFile.GetPrivateProfileString("camera", "pitch", "0.0"));

            SyncControlFirst();


            // ### 업데이트 ###
            _gameLoop.UpdateFrame = (deltaTime) =>
            {
                int w = this.glControl1.Width;
                int h = this.glControl1.Height;

                if (_gameLoop.Width * _gameLoop.Height == 0)
                {
                    _gameLoop.Init(w, h);
                    _gameLoop.Camera.Init(w, h);
                }

                OrbitCamera camera = (OrbitCamera)_gameLoop.Camera;

                this.Text = $"{FramePerSecond.FPS}fps, t={FramePerSecond.GlobalTick} p={camera.Position}";
            };

            //  ### 렌더링 ###
            _gameLoop.RenderFrame = (deltaTime) =>
            {
                OrbitCamera camera = (OrbitCamera)_gameLoop.Camera;

                //Gl.Enable(EnableCap.CullFace);
                //Gl.CullFace(CullFaceMode.Back);

                Gl.ClearColor(0.3f, 0.3f, 0.3f, 1.0f);
                Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                Gl.Enable(EnableCap.DepthTest);

                Gl.Enable(EnableCap.Blend);
                Gl.BlendEquation(BlendEquationMode.FuncAdd);
                Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

                Gl.PolygonMode(MaterialFace.FrontAndBack, _polygonMode);
                foreach (Entity entity in entities)
                {
                    Renderer.Render(_shader, entity, camera);
                }
            };
        }

        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            Camera camera = _gameLoop.Camera;
            if (camera is FpsCamera) camera?.GoForward(0.02f * e.Delta);
            if (camera is OrbitCamera) (camera as OrbitCamera)?.FarAway(-0.005f * e.Delta);
        }

        private void glControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int px = e.X, py = e.Y;
            float width = (float)this.glControl1.Width;
            float height = (float)this.glControl1.Height;
            Vertex3f contactPoint = MousePickUp.PickUp(_gameLoop.Camera, px, py, width, height);
            _gameLoop.Camera.GoTo(contactPoint);
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            if (e.Button == MouseButtons.Right)
                _mouseMode = MOUSE_MOVE_MODE.Orbit;
            else if (e.Button == MouseButtons.Left)
                _mouseMode = MOUSE_MOVE_MODE.Move;
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_gameLoop.Camera is OrbitCamera)
            {
                Camera camera = _gameLoop.Camera;
                Mouse.CurrentPosition = new Vertex2i(e.X, e.Y);
                Vertex2i delta = Mouse.DeltaPosition;
                if (_isMouseDown)
                {
                    if (_mouseMode == MOUSE_MOVE_MODE.Orbit)
                    {
                        camera?.Yaw(-delta.x);
                        camera?.Pitch(delta.y);
                    }
                    else if (_mouseMode == MOUSE_MOVE_MODE.Move)
                    {
                        camera.GoForward(0.05f * delta.y);
                        camera.GoRight(0.05f * -delta.x);
                    }
                }
                Mouse.PrevPosition = new Vertex2i(e.X, e.Y);
            }
        }

        private void glControl1_Render(object sender, GlControlEventArgs e)
        {
            int glLeft = this.Width - this.glControl1.Width;
            int glTop = this.Height - this.glControl1.Height;
            int glWidth = this.glControl1.Width;
            int glHeight = this.glControl1.Height;
            _gameLoop.DetectInput(this.Left + glLeft, this.Top + glTop, glWidth, glHeight);

            // 엔진 루프, 처음 로딩시 deltaTime이 커지는 것을 방지
            if (FramePerSecond.DeltaTime < 1000)
            {
                _gameLoop.Update(deltaTime: FramePerSecond.DeltaTime);
                _gameLoop.Render(deltaTime: FramePerSecond.DeltaTime);
            }
            FramePerSecond.Update();
        }

        private void glControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("정말로 끝내시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 종료 설정 저장
                    IniFile.WritePrivateProfileString("camera", "x", _gameLoop.Camera.Position.x);
                    IniFile.WritePrivateProfileString("camera", "y", _gameLoop.Camera.Position.y);
                    IniFile.WritePrivateProfileString("camera", "z", _gameLoop.Camera.Position.z);
                    IniFile.WritePrivateProfileString("camera", "yaw", _gameLoop.Camera.CameraYaw);
                    IniFile.WritePrivateProfileString("camera", "pitch", _gameLoop.Camera.CameraPitch);

                    Application.Exit();
                }
            }
            else if (e.KeyCode == Keys.F)
            {
                _polygonMode = (_polygonMode == PolygonMode.Fill) ?
                    PolygonMode.Line : PolygonMode.Fill;
            }
            else if (e.KeyCode == Keys.D1)
            {
                Entity ent = (entities.Count > 0) ? entities[0] : null;
                entities.Clear();
                entities.Add(ent);
                MString sentence = CreateTree();
                LoadEntity(sentence, _lSystem.GlobalParameter, _leafFileName, _stemFileName);
            }
        }
        
        private void LoadGlobalParameter()
        {
            _lSystem.AddParameter("d1", this.tbDivergenceAngle1.Value); // divergence angle 1
            _lSystem.AddParameter("d2", this.tbDivergenceAngle2.Value); // divergence angle 2
            _lSystem.AddParameter("a", tbBranchingAngle.Value);          // branching angle
            _lSystem.AddParameter("lr", (float)tbElongationRate.Value * 0.001f);    // elongation rate
            _lSystem.AddParameter("vr", (float)tbWidthIncreaseRate.Value * 0.001f); // width increase rate

            float px = (float)Math.Cos(caTrophism.Value.ToRadian());
            float py = (float)Math.Sin(caTrophism.Value.ToRadian());
            Vertex3f tropismVector = new Vertex3f(px, py, -tbVectorLength.Value).Normalized;
            _lSystem.AddParameter("Tx", tropismVector.x);
            _lSystem.AddParameter("Ty", tropismVector.y);
            _lSystem.AddParameter("Tz", tropismVector.z);

            _lSystem.AddParameter("e", tbBendingConstant.Value * 0.01f);
            _lSystem.AddParameter("leafHeight", tbLeafHeight.Value * 0.01f);
            _lSystem.AddParameter("leafWidth", tbLeafWidth.Value * 0.01f);
            _lSystem.AddParameter("leafRotCount", (float)nmLeafRotCount.Value);            
        }

        public MString CreateTree()
        {
            LoadGlobalParameter();

            float d1 = _lSystem.GlobalParameter["d1"];
            float d2 = _lSystem.GlobalParameter["d2"];
            float a = _lSystem.GlobalParameter["a"];
            float lr = _lSystem.GlobalParameter["lr"];
            float vr = _lSystem.GlobalParameter["vr"];

            MString axiom = (MString)this.textBox1.Text;

            _lSystem.AddRule(ProductionNumber.P1, "A", varCount: 0,
                condition: (t, p, n) => true,
                func: (MChar t, MChar p, MChar n, GlobalParam g) =>
                (MString)$"!({vr})F(50)[&({a})F(50)A]" +
                (MString)$"/({d1})[&({a})F(50)A]" +
                (MString)$"/({d2})[&({a})F(50)A]");

            _lSystem.AddRule(ProductionNumber.P2, "F", varCount: 1,
                condition: (t, p, n) => true,
                func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"F({t[0] * lr})");

            _lSystem.AddRule(ProductionNumber.P3, "!", varCount: 1,
                condition: (t, p, n) => true,
                func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"!({t[0] * vr})");

            Console.WriteLine("axiom=" + axiom);
            MString sentence = _lSystem.Generate(axiom, n: (int)this.nbrStep.Value, isPrintDebug: true);
            Console.WriteLine("result=" + sentence);
            return sentence;
        }

        private void LoadEntity(MString sentence, GlobalParam globalParam, string leafFileName, string stemFileName)
        {
            (RawModel3d branch, RawModel3d leaf) = TreeLoader.Load(sentence, globalParam);
            TexturedModel tree = new TexturedModel(branch, new Texture(EngineLoop.PROJECT_PATH + "\\Res\\" + stemFileName));
            TexturedModel leafModel = new TexturedModel(leaf, new Texture(EngineLoop.PROJECT_PATH + "\\Res\\" + leafFileName));

            Vertex3f f = _gameLoop.Camera.Forward;
            Vertex3f p =_gameLoop.Camera.Position;
            float t = (f.z == 0) ? 0.0f : -p.z / f.z;
            Vertex3f pos = p + f * t;
            Entity e1 = new Entity(tree, PrimitiveType.Triangles);
            e1.IsTextured = true;
            e1.Position = pos;
            entities.Add(e1);

            Entity e2 = new Entity(leafModel, PrimitiveType.Triangles);
            e2.IsTextured = true;
            e2.Position = pos;
            entities.Add(e2);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Entity floor  = entities.Count > 0 ? entities[0] : null;
            entities.Clear();
            entities.Add(floor);
        }

        private void 화면저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width = this.glControl1.Width;
            int height = this.glControl1.Height;
            Bitmap bitmap = new Bitmap(width, height);
            BitmapData bData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.ReadPixels(0, 0, width, height, OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, bData.Scan0);
            bitmap.UnlockBits(bData);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Gl.Finish();
            Clipboard.SetImage(bitmap);
            MessageBox.Show("화면을 캡처하였습니다.");
        }

        private void code읽기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EngineLoop.ShowCursor(true);
            this.openFileDialog1.InitialDirectory = EngineLoop.PROJECT_PATH + "\\Res\\";
            this.openFileDialog1.Filter = "code(*.code)|*.code";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadGlobalParameter();
                MString sentence = (MString)File.ReadAllText(this.openFileDialog1.FileName);
                Console.WriteLine("result=" + sentence);
                LoadEntity(sentence, _lSystem.GlobalParameter, _leafFileName, _stemFileName);
                EngineLoop.ShowCursor(true);
            }
        }

        private void code저장ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EngineLoop.ShowCursor(true);
            this.saveFileDialog1.InitialDirectory = EngineLoop.PROJECT_PATH + "\\Res\\";
            this.saveFileDialog1.Filter = "code(*.code)|*.code";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(this.saveFileDialog1.FileName, _lSystem.Sentence);
                MessageBox.Show("코드를 저장하였습니다.");
                EngineLoop.ShowCursor(true);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MString sentence = CreateTree();
            LoadEntity(sentence, _lSystem.GlobalParameter, _leafFileName, _stemFileName);
        }

        private void tbDivergenceAngle1_Scroll(object sender, EventArgs e)
        {
            lbDivergenceAngle1.Text = "DivergenceAngle1=" + tbDivergenceAngle1.Value;
            IniFile.WritePrivateProfileString("globalParam", "DivergenceAngle1", tbDivergenceAngle1.Value);
        }

        private void tbDivergenceAngle2_Scroll(object sender, EventArgs e)
        {
            lbDivergenceAngle2.Text = "DivergenceAngle2=" + tbDivergenceAngle2.Value;
            IniFile.WritePrivateProfileString("globalParam", "DivergenceAngle2", tbDivergenceAngle2.Value);
        }

        private void tbBranchingAngle_Scroll(object sender, EventArgs e)
        {
            lbBranchingAngle.Text = "BranchingAngle=" + tbBranchingAngle.Value;
            IniFile.WritePrivateProfileString("globalParam", "BranchingAngle", tbBranchingAngle.Value);
        }

        private void tbElongationRate_Scroll(object sender, EventArgs e)
        {
            lbElongationRate.Text = "ElongationRate=" + (tbElongationRate.Value * 0.001f);
            IniFile.WritePrivateProfileString("globalParam", "ElongationRate", tbElongationRate.Value);
        }

        private void tbWidthIncreaseRate_Scroll(object sender, EventArgs e)
        {
            lbWidthIncreaseRate.Text = "WidthIncRate=" + (tbWidthIncreaseRate.Value * 0.001f);
            IniFile.WritePrivateProfileString("globalParam", "WidthIncreaseRate", tbWidthIncreaseRate.Value);
        }

        private void tbBendingConstant_Scroll(object sender, EventArgs e)
        {
            lbBendingConstant.Text = "BendingConstant=" + (tbBendingConstant.Value * 0.01f);
            IniFile.WritePrivateProfileString("globalParam", "BendingConstant", tbBendingConstant.Value);
        }

        private void tbVectorLength_Scroll(object sender, EventArgs e)
        {
            lbTrophismVector.Text = "TropismVecLength=" + tbVectorLength.Value * 0.01f;
            IniFile.WritePrivateProfileString("globalParam", "VectorLength", tbVectorLength.Value);
        }
        private void tbLeafWidth_Scroll(object sender, EventArgs e)
        {
            lbLeafWidth.Text = "leafWidth=" + tbLeafWidth.Value * 0.01f;
            _lSystem.AddParameter("leafWidth", tbLeafWidth.Value * 0.01f);
            IniFile.WritePrivateProfileString("globalParam", "leafWidth", (int)tbLeafWidth.Value);
        }

        private void tbLeafHeight_Scroll(object sender, EventArgs e)
        {
            lbLeafHeight.Text = "leafHeight=" + tbLeafHeight.Value * 0.01f;
            _lSystem.AddParameter("leafHeight", tbLeafHeight.Value * 0.01f);
            IniFile.WritePrivateProfileString("globalParam", "leafHeight", (int)tbLeafHeight.Value);
        }

        private void nmLeafRotCount_ValueChanged(object sender, EventArgs e)
        {
            IniFile.WritePrivateProfileString("globalParam", "leafRotCount", (int)nmLeafRotCount.Value);
            _lSystem.AddParameter("leafRotCount", (float)nmLeafRotCount.Value);
        }

        private void caTrophism_ValueChanged(object sender, EventArgs e)
        {
            IniFile.WritePrivateProfileString("globalParam", "Trophism", caTrophism.Value);
        }

        private void nbrStep_ValueChanged(object sender, EventArgs e)
        {
            IniFile.WritePrivateProfileString("globalParam", "Step", (int)this.nbrStep.Value);
        }

        private void SyncControlFirst()
        {
            string initDirectory = EngineLoop.PROJECT_PATH + "\\Res\\";
            _leafFileName = IniFile.GetPrivateProfileString("globalParam", "leafImage", "");
            _stemFileName = IniFile.GetPrivateProfileString("globalParam", "stemImage", "");
            string leafFileName = initDirectory + _leafFileName;
            string stemFileName = initDirectory + _stemFileName;
            if (File.Exists(leafFileName)) this.pictureBox1.Image = Bitmap.FromFile(leafFileName);
            if (File.Exists(stemFileName)) this.pictureBox2.Image = Bitmap.FromFile(stemFileName);
            nbrStep.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "Step", 5);
            caTrophism.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "Trophism", 45);
            tbWidthIncreaseRate.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "WidthIncreaseRate", 1000);
            tbElongationRate.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "ElongationRate", 1000);
            tbBranchingAngle.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "BranchingAngle");
            tbDivergenceAngle1.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "DivergenceAngle1");
            tbDivergenceAngle2.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "DivergenceAngle2");
            tbBendingConstant.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "BendingConstant");
            tbVectorLength.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "VectorLength", 100);
            tbLeafWidth.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "leafWidth", 100);
            tbLeafHeight.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "leafHeight", 100);
            nmLeafRotCount.Value = (int)IniFile.GetPrivateProfileFloat("globalParam", "leafRotCount", 3);
            RefreshControl();
        }

        private void RefreshControl()
        {
            tbWidthIncreaseRate_Scroll(null, null);
            tbElongationRate_Scroll(null, null);
            tbBranchingAngle_Scroll(null, null);
            tbDivergenceAngle1_Scroll(null, null);
            tbDivergenceAngle2_Scroll(null, null);
            tbBendingConstant_Scroll(null, null);
            tbVectorLength_Scroll(null, null);
            tbLeafWidth_Scroll(null, null);
            tbLeafHeight_Scroll(null, null);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            tbDivergenceAngle1.Value = (int)(_rnd.NextDouble() * 
                (tbDivergenceAngle1.Maximum - tbDivergenceAngle1.Minimum) + tbDivergenceAngle1.Minimum);
            tbDivergenceAngle2.Value = (int)(_rnd.NextDouble() *
                (tbDivergenceAngle2.Maximum - tbDivergenceAngle2.Minimum) + tbDivergenceAngle2.Minimum);
            tbBranchingAngle.Value = (int)(_rnd.NextDouble() *
                (tbBranchingAngle.Maximum - tbBranchingAngle.Minimum) + tbBranchingAngle.Minimum);
            tbElongationRate.Value = (int)(_rnd.NextDouble() *
                (tbElongationRate.Maximum - tbElongationRate.Minimum) + tbElongationRate.Minimum);
            RefreshControl();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = EngineLoop.PROJECT_PATH + "\\Res\\";
            this.openFileDialog1.Filter = "png(*.png)|*.png|jpg(*.jpg)|*.jpg|bmp(*.bmp)|*.bmp";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _leafFileName = this.openFileDialog1.FileName.Replace(this.openFileDialog1.InitialDirectory, "");
                this.pictureBox1.Image = Bitmap.FromFile(this.openFileDialog1.FileName);
                IniFile.WritePrivateProfileString("globalParam", "leafImage", _leafFileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = EngineLoop.PROJECT_PATH + "\\Res\\";
            this.openFileDialog1.Filter = "png(*.png)|*.png|jpg(*.jpg)|*.jpg|bmp(*.bmp)|*.bmp";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _stemFileName = this.openFileDialog1.FileName.Replace(this.openFileDialog1.InitialDirectory, "");
                this.pictureBox2.Image = Bitmap.FromFile(this.openFileDialog1.FileName);
                IniFile.WritePrivateProfileString("globalParam", "stemImage", _stemFileName);
            }
        }

    }
}
