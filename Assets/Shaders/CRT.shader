Shader "Custom/Noise/PseudoRandom"
{
	Properties
	{
		_Factor1 ("Factor 1", float) = 1
		_Factor2 ("Factor 2", float) = 1
		_Factor3 ("Factor 3", float) = 1
		_Speed ("Speed", float) = 1
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			float _Factor1;
			float _Factor2;
			float _Factor3;
			float _Speed;

			float noise(half2 uv)
			{
				return frac(sin(dot(uv, float2(_Factor1 * _Time.x, _Factor2 * _Time.y))) * _Factor3 * _Time) ;
			}

			fixed4 frag (v2f_img i) : SV_Target
			{
				fixed4 col = noise(i.uv);
				return col;
			}
			ENDCG
		}
	}
}