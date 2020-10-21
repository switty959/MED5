Shader "Tutorial/Diffuse"
{
    Properties
    {
        _color("Color",color) = (1,1,1,1)
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


            float4 _color;
            
            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR0;
            };

            v2f vert(appdata_base v)
            {
                v2f output;

                output.pos = UnityObjectToClipPos(v.vertex);

                half3 normalsInWorldSpace = normalize(UnityObjectToWorldNormal(v.normal));
                half diffuseAmount = dot(normalsInWorldSpace, _WorldSpaceLightPos0.xyz);

                output.color = _LightColor0 * diffuseAmount * _color;

                return output;
            }

            fixed4 frag(v2f input) : COLOR
            {
                fixed4 color = input.color;
                return color;
            }
            

            ENDCG
        }
    }
}
