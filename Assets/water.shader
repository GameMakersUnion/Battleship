Shader "Custom/water" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Color2 ("Color 2", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_Noise ("Noise", 2D) = "white" {}
		_Amplitude ("Amplitude", Float) = 1.0
		_CurrentSpeed ("Current Speed", Float) = 1.0
	}
	SubShader {
		Pass {
			Tags { "RenderType"="Opaque" }
			CGPROGRAM
		
			// Compiler Directives
			#pragma exclude_renderers xbox360 ps3 flash
			#pragma vertex VS_MAIN
			#pragma fragment FS_MAIN
			
			// Predefined variables and helper functions (Unity specific)
			#include "UnityCG.cginc"
			
			// Uniform Variables (Properties)
			uniform float4 _Color;
			uniform float4 _Color2;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform sampler2D _Noise;
			uniform float _Amplitude;
			uniform float _CurrentSpeed;
			
			// Input Structs
			struct FS_INPUT {
				float4 pos		: SV_POSITION;
				half2 uv		: TEXCOORD0;
			};
			
			// VERTEX FUNCTION
			FS_INPUT VS_MAIN (appdata_base input) {
				FS_INPUT output;
				
				// Setting FS_MAIN input struct
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				output.uv = TRANSFORM_TEX(input.texcoord, _MainTex);
				
				return output;
			}
			
			// FRAGMENT FUNCTION
			fixed4 FS_MAIN (FS_INPUT input) : COLOR {
				float t = sin(_CurrentSpeed * _SinTime + input.uv.x + input.uv.y) + cos(_CurrentSpeed * _SinTime * 2 + input.uv.x)+ cos(_CurrentSpeed * _SinTime * 1.5 + input.uv.y);
				float4 color = lerp(_Color, _Color2, t);
				return color;
				//return tex2D(_Noise, input.uv) * _Color;
			}
		
			ENDCG
			
		}
	} 
	//FallBack "Diffuse"
}
