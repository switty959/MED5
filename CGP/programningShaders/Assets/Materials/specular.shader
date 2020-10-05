// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Tutorial/spec" 
{
	Properties
	{
		_color ("Color",Color) = (1,1,1,1)
		_specColor ("Specular Color",Color) = (1,1,1,1)
		_Shininess ("Shininess",Float) = 10
	}
		SubShader
	{
		
		Pass
		{
			Tags
			{
			"LightMode" = "ForwardBase"
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			//variable from the inspector
			half4 _color;
			float4 _specColor;
			float4 _Shininess;

			//unity variable
			float4 _LightColor0;


			//structs
			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col: COLOR;
			};


			//vertex function
			vertexOutput vert(vertexInput input)
			{
				vertexOutput o;

				//vectors
				float4 normal = float4(input.normal, 0.0);
				float3 n = normalize(mul(normal, unity_WorldToObject));
				float3 l = normalize(_WorldSpaceLightPos0);
				float3 v = normalize(_WorldSpaceCameraPos);

				float NdotL = max(0.0,dot(n,1));
				float3 a = UNITY_LIGHTMODEL_AMBIENT * _color;
				float3 d = NdotL * _LightColor0 * _color;
				float3 r = reflect(-l,n);
				float RdotV = max(0.0, dot(r, v));
				float3 s = float3(0, 0, 0);
				if (dot(n,l)>0.0)
				{
					s = _LightColor0 * _specColor * pow(RdotV, _Shininess);

				}
				float4 c = float4(d+a+s,1.0);
				o.col = c;
				o.pos = UnityObjectToClipPos(input.vertex);

				return o;
			}

			half4 frag(vertexOutput input) : COLOR
			{
				return saturate(input.col);
			}
			ENDCG
		}
	}
	//Falback "Diffuse"
		
}