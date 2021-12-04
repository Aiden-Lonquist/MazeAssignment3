Shader "Custom/DayNightShader"
{
    Properties{
      _MainTex("Texture", 2D) = "white" {}
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }

            CGPROGRAM
            #pragma surface surf Lambert

            struct Input {
                float2 uv_MainTex;
            };

            sampler2D _MainTex;

            void surf(Input i, inout SurfaceOutput o) {
                o.Albedo = tex2D(_MainTex, i.uv_MainTex).rgb;
            }

            ENDCG
    }
        Fallback "Diffuse"
}