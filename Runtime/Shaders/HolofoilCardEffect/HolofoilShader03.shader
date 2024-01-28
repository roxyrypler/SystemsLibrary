Shader "Custom/HolofoilEffect"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _HoloTex ("Holofoil Texture", 2D) = "white" {}
        _ColorShift ("Color Shift", Color) = (1,1,1,1)
        _SparkleScale ("Sparkle Scale", Float) = 1.0
        _SparkleIntensity ("Sparkle Intensity", Float) = 1.0
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
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float4 vertex : SV_POSITION;
                float3 colorShift : TEXCOORD2;
                float ndotv : TEXCOORD3; // Normal dot View direction
            };

            sampler2D _MainTex;
            sampler2D _HoloTex;
            float4 _MainTex_ST;
            float4 _HoloTex_ST;
            float4 _ColorShift;
            float _SparkleScale;
            float _SparkleIntensity;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.viewDir = normalize(mul(UNITY_MATRIX_MV, v.vertex).xyz);

                // Normal and view direction calculations
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 viewDir = normalize(-mul(UNITY_MATRIX_MV, v.vertex).xyz);
                o.ndotv = max(0, dot(worldNormal, viewDir));

                // Color shift based on view direction
                o.colorShift = lerp(_ColorShift.xyz, 1.0, abs(dot(viewDir, worldNormal)));

                return o;
            }

            // Simple noise function for sparkle effect
            float SparkleNoise(float2 uv, float time)
            {
                // A simple noise algorithm for demonstration
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453 + time);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Sample the main texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Calculate the holofoil effect based on the view direction
                float3 holoEffect = tex2D(_HoloTex, i.uv + i.viewDir.xy * _HoloTex_ST.xy).rgb;

                // Apply color shift
                holoEffect *= i.colorShift;

                // Sparkling effect based on view angle
                float sparkle = SparkleNoise(i.uv * _SparkleScale, _Time.y) * _SparkleIntensity;
                sparkle *= i.ndotv; // Modulate sparkle based on view angle
                col.rgb += sparkle * holoEffect;

                // Combine the main texture and the holofoil effect
                col.rgb = lerp(col.rgb, holoEffect, holoEffect);

                return col;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
