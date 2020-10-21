Shader "ShaderChallenges/challenge_1.0"
{

	Properties
	{
		_firstColor("First Color",color) = (1,1,1,1)
		_secondColor("Second Color",color) = (1,1,1,1)
		_thirdColor("Third Color",color) = (1,1,1,1)
	}

		SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float4 _firstColor;
			float4 _secondColor;
			float4 _thirdColor;


			struct v2f
			{
				float4 pos : SV_POSITION;
			};

			v2f vert(appdata_base v)
			{
				v2f output;

				output.pos = UnityObjectToClipPos(v.vertex);
				return output;
			}

			fixed4 frag(v2f input, uint triangleID:SV_PrimitiveID) : SV_Target
			{
				
				return _firstColor;
			}

	ENDCG
}
	}
}
