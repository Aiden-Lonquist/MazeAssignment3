Shader "Custom/SkyboxShader"
{
    Properties{
        //variables accessible in Unity added here
        _Color("Color", Color) = (0, 0, 0, 1)
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
        #pragma fragment frag2

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

        v2f vert(appdata v)
        {
            v2f o;
            o.position = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv; //directly pass uv data to fragment shader
            return o;
        }

        //fragment shader
        fixed4 frag2(v2f i) : SV_TARGET{
            return _Color;
        }
            ENDCG
        }
    }
}
