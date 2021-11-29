// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/* 

illum shader.

self illumination based on base texture alpha channel.

*/

Shader "RangerWars/CeilingLight" {
	
Properties {
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_SelfIllumination ("Self Illumination", Range(0.0,4.0)) = 4.0
	_Color ("Tint Color", Color) = (1,1,1,1)
}

SubShader {
	Pass {		

		CGPROGRAM
		
		#pragma vertex vert
		#pragma fragment frag
		
		#include "UnityCG.cginc"
		
		uniform half4 _MainTex_ST;
		uniform sampler2D _MainTex;
		uniform fixed _SelfIllumination;
		float4 _Color;
		
		struct v2f
		{
			half4 pos : POSITION;
			half2 uv : TEXCOORD0;
		};
		
		v2f vert (appdata_base v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);	
			o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
			
			return o; 
		}
		
		half4 frag (v2f i) : COLOR 
		{
			fixed4 tex = tex2D(_MainTex, i.uv.xy);
			return tex * tex.a * _SelfIllumination * _Color;
		}
		
		ENDCG
	}
}

FallBack Off
}
