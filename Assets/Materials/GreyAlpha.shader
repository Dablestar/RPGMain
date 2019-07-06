Shader "Custom/GreyAlpha" //경로
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Alpha("Alpha", Range(0,1)) = 1
       
    }
    SubShader
    {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade//그림자를 가능하게 해주는 부분

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex; //float * 2 (x, y같이 실수형 변수 2개)
        };

        //half _Glossiness; //실수
        //half _Metallic;
		float _Alpha;
        fixed4 _Color;//실수

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color  알베도 = 색상
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color; //tex2D = 컬러값을 만들어내기 위해서
			o.Albedo = c.rgb; //( c.r + c.g + c.b )/3; //모든 값을 더해서 3으로 나눠주면 흑백화됨. (원본값 = c.rgb)
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
