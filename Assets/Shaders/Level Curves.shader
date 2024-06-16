Shader "Custom/TopographicShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _LineWidth ("Line Width", Float) = 0.02
    }

    SubShader {
        Tags {"RenderType" = "Opaque"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float _LineWidth;

        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            float3 color = float3(0.0, 0.0, 0.0);
            float height = IN.worldPos.y;
            
            float level = frac(height);

            o.Albedo = lerp(color, float3(1.0, 1.0, 1.0), step(_LineWidth, level) - step(1.0 - _LineWidth, level));
            o.Alpha = 1.0;
        }
        ENDCG
    }

    FallBack "Diffuse"
}