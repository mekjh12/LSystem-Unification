﻿#version 420 core

in vec3 position;
in vec2 textureCoords;
in vec3 color;

uniform mat4 model;
uniform mat4 proj;
uniform mat4 view;

out vec2 texCoords;
out vec4 fcolor;

void main(void)
{
    vec4 camPosition = view * model * vec4(position, 1.0);
    gl_Position = proj * camPosition;
    texCoords = textureCoords;
    fcolor = vec4(color, 1.0f);
}