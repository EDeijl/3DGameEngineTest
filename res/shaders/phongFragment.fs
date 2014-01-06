#version 330

in vec2 texCoord0;

out vec4 fragColor;

uniform vec3 baseColor;
uniform vec3 ambientLight;
uniform sampler2D sampler;

struct BaseLight
{
	vec3 color;
	float intensity;
};

struct DirectionalLight
{
	BaseLight base;
	vec3 direction;
};

void main()
{ 
    vec4 totalLight = vec4(ambientLight,1);
    vec4 color = vec4(baseColor, 1);
    vec4 textureColor = texture(sampler, texCoord0.xy);
    
    if(textureColor != vec4(0,0,0,0))
        color *= textureColor;
        
    fragColor = color * totalLight;
}