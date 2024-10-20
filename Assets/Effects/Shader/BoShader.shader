Shader "Custom/LaserCannonShaderWithGlow"
{
    Properties
    {
        _Color ("Laser Color", Color) = (1, 0, 0, 1) // ������ɫ
        _Width ("Laser Width", Float) = 0.2 // ������
        _HaloWidth ("Halo Width", Float) = 0.5 // ���ο��
        _Intensity ("Laser Intensity", Float) = 1.0 // ����ǿ��
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
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
            float _Width;
            float _HaloWidth;
            float _Intensity;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // ���㼤���������
                float distanceFromCenter = abs(i.uv.x - 0.5); // ����������X���0.5��

                // �������Ч��
                float glowEffect = smoothstep(_Width, _Width + _HaloWidth, distanceFromCenter);

                // ���㼤����ɫ
                fixed4 color = _Color * (1.0 - glowEffect); // �м䲿����ɫ��ǿ����Ե����
                fixed4 glowColor = fixed4(_Color.rgb, _Color.a * glowEffect * _Intensity); // ����Ч��

                // �ϳ���ɫ
                return color + glowColor; // �ϳɼ���͹��ε���ɫ
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
