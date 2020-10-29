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
            #pragma target 3.5
            #include "UnityCG.cginc"

            float4 _firstColor;
            float4 _secondColor;
            float4 _thirdColor;

        // vertex input: position, color
        struct v2f {
            fixed4 color : TEXCOORD0;
            float4 pos : SV_POSITION;
        };
        
        v2f vert 
            (
                float4 vertex : POSITION,
                uint vid : SV_VertexID
            ) 
            {
            v2f o;
            o.pos = UnityObjectToClipPos(vertex);
            float f = (float)vid;
            if (f ==2 || f ==3)
            {
                o.color = _firstColor;
            }
            if (f == 1)
            {
                o.color = _secondColor;
            }
            if (f == 0 )
            {
                o.color = _thirdColor;
            }
            
                
            return o;

            }
        
        fixed4 frag(v2f i) : SV_Target
        {
            return i.color; 
        }
        ENDCG
    }
}
}
