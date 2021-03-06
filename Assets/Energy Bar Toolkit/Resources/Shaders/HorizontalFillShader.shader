Shader "Custom/Energy Bar Toolkit/Horizontal Fill" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Color (RGB)", Color) = (1, 1, 1, 1)
        _Rect ("Visible Rect", Vector) = (0, 0, 1, 1)
        _Progress ("Progress", Float) = 0.5
        _Invert ("Invert", Float) = 0.0
    }
    SubShader {
        Tags { "Queue"="Transparent" "LightMode"="Always"}
        Blend One OneMinusSrcAlpha
        
        CGPROGRAM
        #pragma surface surf NoLighting noforwardadd noambient

        sampler2D _MainTex;
        fixed4 _Color;
        float4 _Rect;
        half _Progress;
        float _Invert;

        struct Input {
            float2 uv_MainTex;
        };
        
        bool isVisible(half2 p, half progress) {
            if (_Invert == 0) { // left to right
                float x = p.x - _Rect.x;
                float w = _Rect.z - _Rect.x;
                return progress >= x / w;
            } else { // right to left
                float x = p.x - _Rect.x;
                float w = _Rect.z - _Rect.x;
                return 1 - progress <= x / w;
            }
        }
        
        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D(_MainTex, IN.uv_MainTex);
            
            if (!isVisible(IN.uv_MainTex, _Progress)) {
                // NOTE: due to Unity bug this statement must be done after tex2D()
                discard;
            }
            
            c.rbg *= c.a;
            
            o.Albedo = c.rgb * (half3) _Color;
            o.Alpha = c.a * _Color.a;
        }
        
        half4 LightingNoLighting (SurfaceOutput s, half3 lightDir, half atten) {
            half4 c;
            c.rgb = s.Albedo;
            c.a = s.Alpha;
            return c;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
