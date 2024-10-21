Shader "Unlit/FixImageShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Percent("Percent",range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            float4 _MainTex_ST;

            float _Percent;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                col.r =lerp (col.r,(col.r * col.r / 0.5 ) * step(col.r, 0.5) + ( 1 - (1-col.r)* (1-col.r) /0.5 ) * step(0.5, col.r),_Percent);
                col.g =lerp (col.g,(col.g * col.g / 0.5 ) * step(col.g, 0.5) + ( 1 - (1-col.g)* (1-col.g) /0.5 ) * step(0.5, col.g),_Percent);
                col.b =lerp (col.b,(col.b * col.b / 0.5 ) * step(col.b, 0.5) + ( 1 - (1-col.b)* (1-col.b) /0.5 ) * step(0.5, col.b),_Percent);

                return col;
            }
            ENDCG
        }
    }
}
