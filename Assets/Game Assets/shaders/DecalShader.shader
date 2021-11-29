// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/* 

illum shader.

self illumination based on base texture alpha channel.

*/

Shader "RangerWars/DecalShader" {
	
Properties {
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_Color ("Tint Color", Color) = (1,1,1,1)
	_DecalTex ("Decal (RGBA)", 2D) = "white" {} 
	_ColorDecal ("Decal Color", Color) = (1,1,1,1)
}

SubShader {
	Pass {		

		CGPROGRAM
		
		#pragma vertex vert
		#pragma fragment frag
		
		#include "UnityCG.cginc"
		
		uniform half4 _MainTex_ST;
		uniform sampler2D _MainTex;
		float4 _Color;
		float4 _ColorDecal;
		sampler2D _DecalTex;
		
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
			tex = tex * tex.a * _Color;
			fixed4 decal = tex2D (_DecalTex, i.uv.xy); //decal texture
			decal = decal * decal.a * _ColorDecal;
			fixed temp = tex + decal;
			return lerp(tex, decal, temp);
		}
		
		ENDCG
	}
}

FallBack Off
}
