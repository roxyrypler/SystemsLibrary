Shader "Custom/HolofoilShader01"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _HoloFoilTex ("Foil Texture", 2D) = "white" {}
        _Scale ("Plasma Scale", float) = 1
        _Intensity ("Foil Intensity", float) = 1
        _ColorOne ("Color One", Color) = (1, 1, 1, 1)
        _ColorTwo ("Color Two", Color) = (1, 1, 1, 1)
        _ColorThree ("Color Three", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 viewDir : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _HoloFoilTex;
            float _Scale, _Intensity;

            float4 _ColorOne, _ColorTwo, _ColorThree;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.viewDir = WorldSpaceViewDir(v.vertex);
                return o;
            }

            float3 Plasma(float2 uv)
            {
                uv = uv * _Scale - _Scale / 2;
                float time = 0;
                float w1 = sin(uv.x + time);
                float w2 = sin(uv.y + time);
                float w3 = sin(uv.x + uv.y + time);

                float r = sin(sqrt(uv.x * uv.x + uv.y * uv.y) + time) * 2;

                float finalValue = w1 + w2 + w3 + r;

                float3 c1 = sin(finalValue * UNITY_PI) * _ColorOne;
                float3 c2 = cos(finalValue * UNITY_PI) * _ColorTwo;
                float3 c3 = sin(finalValue) * _ColorThree;
                return c1 + c2 + c3;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 foil = tex2D(_HoloFoilTex, i.uv);
                float2 newUV = i.viewDir.xy + foil.rg;
                float3 plasma = Plasma(newUV) * _Intensity;
                fixed4 col = tex2D(_MainTex, i.uv);
                return fixed4(col.rgb + col.rgb * plasma.rgb, 1);
            }
            ENDCG
        }
    }
}
