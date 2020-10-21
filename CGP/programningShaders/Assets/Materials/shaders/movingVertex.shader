Shader "Tutorial/movingVertex"
{
	Properties
	{
		_MainTexture("Texture", 2D) = "white"{}
		_Color("Colour",Color) = (1,1,1,1)
		_Offset("Vertex Offset",Float) = (0,0,0,0)
		_AnimationSpeed("Animation",Range(0,3)) = 0
		_OffsetSize("Offset size", Range(0, 10)) = 0
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

			fixed4 _Offset;
			fixed4 _Color;
			sampler2D _MainTexture;
			float _AnimationSpeed;
			float _OffsetSize;

			v2f vertexFunc(appdata IN)
			{
				v2f OUT;

				IN.vertex.x += sin(_Time.y * _AnimationSpeed + IN.vertex.y * _OffsetSize);

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			fixed4 fragementFunc(v2f IN) : SV_Target
			{
				fixed pixelColor = tex2D(_MainTexture, IN.uv);

			return pixelColor * _Color;
			}

			ENDCG
		}
	}
}