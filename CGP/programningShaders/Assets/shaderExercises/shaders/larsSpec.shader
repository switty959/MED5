Shader "Unlit/larsSpec"
{
    Properties
    {
        _Shininess("Shininess",Float) = 10
    }
    SubShader
    {


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            float4 _Shininess;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;

            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.worldNormal = normalize(mul(v.normal,(float3x3)unity_WorldToObject));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col =  fixed4(0,0,0,1);

                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz); 
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.worldPos);

                float3 worldNormal = normalize(i.worldNormal);

                float3 reflectionDir = normalize(reflect(-lightDirection, worldNormal));

                fixed4 NdotL = max(0,dot(worldNormal, lightDirection));

                float RdotV = max(0, dot(reflectionDir, viewDirection));

                fixed4 specColor = _LightColor0 * pow(RdotV, _Shininess) * NdotL;

                col.rgb += specColor.rgb;

                return col;
            }
            ENDCG
        }
    }
}
