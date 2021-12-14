Shader "Custom/Potal"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white"{}
	}

		CGINCLUDE

#include "UnityCG.cginc"

		sampler2D _MainTex;
	sampler2D _SubTex;
	float _Aspect;
	float _Radius;
	float2 _Position;

	float4 frag(v2f_img i) : SV_Target
	{
		float width = 0.07;

	// ���g�̃s�N�Z������|�[�^�����S�܂ł̋���
	float distance = length((_Position - i.uv) * float2(1, _Aspect));

	// ���g�̃s�N�Z���ʒu�ł̘c�݋
	float distortion = 1 - smoothstep(_Radius - width, _Radius, distance);

	// ���g�̃s�N�Z���ʒu�ł̘c�݋������
	// �|�[�^�����S�̕��ւ��炵�� uv ���v�Z���܂�
	float uv = i.uv + (_Position - i.uv) * distortion;

	// �v�Z���� uv �� _MainTex �̃J���[���o�͂��܂�
	// �|�[�^�����ɈႤ�G���o�����߂ɁA
	// lerp + step �ŏo�̓e�N�X�`����؂�ւ��Ă��܂�
	return lerp(tex2D(_MainTex, uv),
				tex2D(_SubTex, i.uv),
				step(1, distortion));
	}
		ENDCG

		SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			ENDCG
		}
	}
}
