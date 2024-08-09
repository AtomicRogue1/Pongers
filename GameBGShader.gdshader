shader_type canvas_item;

uniform vec4 desiredColor : source_color;
uniform float timeFactor : hint_range(0.0, 10.0, 0.5) = 1;
uniform float waveFrequency : hint_range(0.0, 10.0, 0.1) = 1.0;

void fragment() {
    vec2 uv = UV;
    float wave = abs(sin(uv.x * waveFrequency + TIME * timeFactor));
    
    vec4 color = vec4(
        mix(0.0, desiredColor.r, wave),
        mix(0.0, desiredColor.g, wave),
		mix(0.0, desiredColor.b, wave),
        1.0
    );
    
    COLOR = texture(TEXTURE, UV) * color;
}