Shader "Tutorial/flat"
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

					float4 _color;
					

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

					fixed4 frag(v2f input) : COLOR
					{
						return _color;
					}

			ENDCG
		}
	}
}