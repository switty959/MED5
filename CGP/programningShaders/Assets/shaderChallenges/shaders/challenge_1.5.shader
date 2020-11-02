Shader "ShaderChallenges/challenge_1.5"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_MainTex2("Albedo 2 (RGB)", 2D) = "white" {}
		_Color("Nighttime Color Filter",Color) = (1,1,1,1)
	}
		SubShader
		{
			Pass
			{

				Tags{"LightMode" = "ForwardBase"}

				CGPROGRAM

				#pragma vertex vertexFunc
				#pragma fragment fragementFunc

				#include "UnityCG.cginc"

				uniform float4 _LightColor0;

				sampler2D _mainTex;
				sampler2D _mainTex2;
				float4 _Color;

				struct vertexInput
				{
					float4 vertex : POSITON;
					float4 texcoord : TEXCOORD0;
					float3 normal : NORMAL;
				};

				struct vertexOutput
				{
					float4 pos : SV_POSITION;
					float4 tex : TEXCOORD0;
					float levelOfLighting : TEXCOORD1;
				};

				vertexOutput vertexFunc(vertexInput IN)
				{
					vertexOutput output;
					
					float4x4 modelMatrix = unity_ObjectToWorld;
					float4x4 modelMatrixInverse = unity_WorldToObject;

					float3 normalDir = normalize(mul(float4(IN.normal, 0.0), modelMatrixInverse).xyz);
					float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

					output.levelOfLighting = max(0.0, dot(normalDir, lightDir));
					output.tex = IN.texcoord;
					output.pos = UnityObjectToClipPos(IN.vertex);

					return output;

				}

				fixed4 fragementFunc(vertexOutput IN) : COLOR
				{
					float4 nighttimeColor = tex2D(_mainTex, IN.tex.xy) * _Color;
					float4 daytimeColor = tex2D(_mainTex2,IN.tex.xy)*_LightColor0;

					return lerp(nighttimeColor,daytimeColor,IN.levelOfLighting);
				}


			ENDCG
		}
	}
}
