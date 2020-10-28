﻿Shader "ShaderChallenges/challenge_1.1"
{

	Properties
	{
		_firstColor("First Color",color) = (1,1,1,1)
		_secondColor("Second Color",color) = (1,1,1,1)
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


			struct v2f
			{
				float4 pos : SV_POSITION;
				fixed4 color : COLOR;
			};

			v2f vert(appdata_base v)
			{
				v2f output;
				output.color.r = 1 * abs(_SinTime.w);
				output.color.b = 1 * abs(_CosTime.w);
				output.pos = UnityObjectToClipPos(v.vertex);

				return output;
			}

			fixed4 frag(v2f input) : SV_Target
			{
				

				return input.color;
			}

	ENDCG
}
	}
}
