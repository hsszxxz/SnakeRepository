Shader "Custom/2DFanRingShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Radius ("Outer Radius", Float) = 1.0
        _InnerRadius ("Inner Radius", Float) = 0.5
        _Angle ("Angle", Float) = 90.0 // ���εĽǶ�
        _Scale ("Scale", Float) = 1.0 // �������λ��ĺ��
        _Aerf("Aey",Color) =(0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
       Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Radius;
            float _InnerRadius;
            float _Angle;
            float _Scale; // ���������Ų���
            fixed4 _Aerf;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // ��UV����ת��������
                float2 center = float2(0.5, 0.5);  // UV����
                float2 uv = i.uv - center;
                
                // ���㵱ǰ���صĽǶȺͰ뾶
                float angle = atan2(uv.y, uv.x) * 180.0 / 3.14159;
                float radius = length(uv);

                // ����Scale�����ڰ뾶����뾶
                float adjustedInnerRadius = _InnerRadius +_Scale;

                // �жϵ�ǰ���Ƿ������η�Χ��
                bool inInnerCircle = radius < adjustedInnerRadius;
                bool inOuterCircle = radius < _Radius;
                bool inAngle = angle > (-_Angle / 2.0) && angle < (_Angle / 2.0);

                // ��������������ڣ�������ɫ
                if (inOuterCircle && inAngle && !inInnerCircle)
                {
                    return _Color; // ������ɫ
                }
                
                return _Aerf;  // ���������ڣ�����͸��
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
