Shader "ShaderChallenges/challenge_1.2"
{
    Properties{
     _MainTex("Albedo (RGB)", 2D) = "white" {}
     _MainTex2("Albedo 2 (RGB)", 2D) = "white" {}
    }
        SubShader{

            CGPROGRAM
         // Physically based Standard lighting model, and enable shadows on all light types
         #pragma surface surf Standard


         sampler2D _MainTex;
         sampler2D _MainTex2;

         struct Input {
             float2 uv_MainTex;
             float2 uv_MainTex2;
         };

         half _Blend;

         void surf(Input IN, inout SurfaceOutputStandard o) {
             // Albedo comes from a texture tinted by color
             _Blend = abs(_SinTime.w);
             fixed4 c = lerp(tex2D(_MainTex, IN.uv_MainTex), tex2D(_MainTex2, IN.uv_MainTex2), _Blend);


             o.Albedo = c.rgb;

             o.Alpha = c.a;
         }
         ENDCG
     }

}
