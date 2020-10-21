Shader "Tutorial/texture"
{
	Properties
	{
		_MainTexture("Texture", 2D) = "white"{}
		_Color("Colour",Color) = (1,1,1,1)
		_xOffset("XOffset", Range(0,10)) = 1.0
		_yOffset("YOffset", Range(0,10)) = 1.0
		_AnimationSpeed("AnimationSpeed", Range(0,10)) = 1.0

	}

	SubShader
	{
			Cull Front
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

			fixed4 _Color;
			sampler2D _MainTexture;
			float _xOffset;
			float _yOffset;
			float _animationSpeed;


			v2f vertexFunc(appdata IN)
			{
				v2f OUT;

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			fixed4 fragementFunc(v2f IN) : SV_Target
			{
				//IN.uv.x += _SinTime.w;
				//IN.uv.y += _CosTime.w;

				IN.uv.x = 0.24 + IN.uv.x * 0.52;
				IN.uv.y = 0.24 + IN.uv.y * 0.52;

				fixed pixelColor = tex2D(_MainTexture, IN.uv);

			return pixelColor * _Color;
			}

			ENDCG
		}
	}
}