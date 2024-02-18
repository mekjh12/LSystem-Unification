#version 420 core
in vec2 texCoords;

uniform sampler2D modelTexture;
uniform bool isTextured;
uniform vec4 color;

out vec4 out_Color;

void main(void)
{
    vec4 textureColor4 = texture(modelTexture, texCoords);
    if (textureColor4.a < 0.05f) discard;
    out_Color = isTextured ? vec4(color.xyz, 1) * textureColor4 : vec4(color.xyz, 1);  
    //out_Color = vec4(textureColor4.xyz, 1);
}