Shader "Custom/DayNightShader"
{

    Properties{
        _Color("Color", Color) = (0,0,0,1)
        _MainTex("Texture", 2D) = "white" {}
    }
        Subshader{
            Pass{
                Tags{
                    "RenderType" = "Opaque"
                    "Queue" = "Geometry"
                }

                CGPROGRAM
                #include "unityCG.cginc"

                #pragma vertex vert
                #pragma fragment frag

                sampler2D _MainTex;
                fixed4 _Color;

                //input data from 3d model to vertex shader
                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                //output data from vertex shader to rasterizer
                struct v2f {
                    float4 position : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(appdata v) {
                    v2f o;
                    o.position = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_TARGET{
                    fixed4 col = tex2D(_MainTex, i.uv);
                    return col * _Color;
                }

                ENDCG
            }
    }
}