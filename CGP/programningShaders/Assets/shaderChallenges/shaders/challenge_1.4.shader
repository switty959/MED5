Shader "ShaderChallenges/challenge_1.4"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_MainTex2("Albedo 2 (RGB)", 2D) = "white" {}
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex vertexFunc
			#pragma fragment fragementFunc

			#include "UnityCG.cginc"
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{

				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;

			};

			sampler2D _MainTex;
			sampler2D _MainTex2;




			v2f vertexFunc(appdata IN)
			{
				v2f OUT;

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			fixed4 fragementFunc(v2f IN) : SV_Target
			{
				fixed4 pixelColor;

				if (pow(IN.uv.x-0.5,2)+ pow(IN.uv.y-0.5,2) < _SinTime.w * 0.5 + 0.5)
				{
						pixelColor = tex2D(_MainTex, IN.uv);
						return pixelColor;
					
				}
				else
				{
					pixelColor = tex2D(_MainTex2, IN.uv);
					return pixelColor;
				}


			}

			ENDCG
		}
	}
}
