Shader "Custom/LaserCannonShaderWithGlow"
{
    Properties
    {
        _Color ("Laser Color", Color) = (1, 0, 0, 1) // 激光颜色
        _Width ("Laser Width", Float) = 0.2 // 激光宽度
        _HaloWidth ("Halo Width", Float) = 0.5 // 光晕宽度
        _Intensity ("Laser Intensity", Float) = 1.0 // 激光强度
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
                // 计算激光的中心线
                float distanceFromCenter = abs(i.uv.x - 0.5); // 激光中心在X轴的0.5处

                // 计算光晕效果
                float glowEffect = smoothstep(_Width, _Width + _HaloWidth, distanceFromCenter);

                // 计算激光颜色
                fixed4 color = _Color * (1.0 - glowEffect); // 中间部分颜色更强，边缘渐变
                fixed4 glowColor = fixed4(_Color.rgb, _Color.a * glowEffect * _Intensity); // 光晕效果

                // 合成颜色
                return color + glowColor; // 合成激光和光晕的颜色
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
