Shader "ShaderChallenges/challenge_1.0"
{

    Properties
    {
        _firstColor("First Color",color) = (1,1,1,1)
        _secondColor("Second Color",color) = (1,1,1,1)
        _thirdColor("Third Color",color) = (1,1,1,1)
    }

        SubShader{
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _firstColor;
            float4 _secondColor;
            float4 _thirdColor;

        // vertex input: position, color
        struct appdata {
            float4 vertex : POSITION;
            fixed4 color : COLOR;
        };

        struct v2f {
            float4 pos : SV_POSITION;
            fixed4 color : COLOR;
        };
        
        v2f vert (appdata v) {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex );
            o.color.z = o.pos +_firstColor;
            return o;
        }
        
        fixed4 frag(v2f i) : SV_Target
        {
            i.pos.x = i.pos.x + 50;
            return i.color; 
        }
        ENDCG
    }
}
}
