// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,cmtg:SF,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,acwp:False,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:35604,y:32660,varname:node_3138,prsc:2|normal-6039-OUT,emission-6740-OUT,custl-4320-OUT;n:type:ShaderForge.SFN_LightVector,id:8842,x:32485,y:32697,varname:node_8842,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:3391,x:32485,y:32849,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:411,x:32704,y:32697,varname:node_411,prsc:2,dt:1|A-8842-OUT,B-3391-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:1090,x:32704,y:32859,varname:node_1090,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7430,x:32903,y:32697,varname:node_7430,prsc:2|A-411-OUT,B-1090-OUT;n:type:ShaderForge.SFN_Set,id:2528,x:33109,y:32604,varname:ShadowData,prsc:2|IN-7430-OUT;n:type:ShaderForge.SFN_LightColor,id:1989,x:32903,y:32859,varname:node_1989,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5419,x:33109,y:32697,varname:node_5419,prsc:2|A-7430-OUT,B-1989-RGB;n:type:ShaderForge.SFN_Set,id:2993,x:33304,y:32697,varname:LightData,prsc:2|IN-5419-OUT;n:type:ShaderForge.SFN_Get,id:6510,x:34734,y:33043,varname:node_6510,prsc:2|IN-2993-OUT;n:type:ShaderForge.SFN_Relay,id:1034,x:32485,y:32594,cmnt:Lisht And Shadows,varname:node_1034,prsc:2;n:type:ShaderForge.SFN_Relay,id:5849,x:32583,y:34586,cmnt:Textures,varname:node_5849,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:1426,x:33166,y:34821,ptovrint:False,ptlb:EarthTex,ptin:_EarthTex,varname:node_1426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b0b34e5bbcab38b49a1aecb39521277a,ntxv:0,isnm:False|UVIN-5025-UVOUT;n:type:ShaderForge.SFN_Set,id:5401,x:33430,y:34821,varname:EarthMain,prsc:2|IN-1426-RGB;n:type:ShaderForge.SFN_Get,id:9233,x:34734,y:32913,varname:node_9233,prsc:2|IN-5401-OUT;n:type:ShaderForge.SFN_Multiply,id:4163,x:35164,y:32911,varname:node_4163,prsc:2|A-9598-OUT,B-6510-OUT;n:type:ShaderForge.SFN_Panner,id:5025,x:32858,y:34870,varname:node_5025,prsc:2,spu:1,spv:0|UVIN-4878-UVOUT,DIST-9404-OUT;n:type:ShaderForge.SFN_TexCoord,id:4878,x:32435,y:35025,varname:node_4878,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:8236,x:31937,y:35048,varname:node_8236,prsc:2;n:type:ShaderForge.SFN_Slider,id:2569,x:32165,y:34761,ptovrint:False,ptlb:EarthSpinSpd,ptin:_EarthSpinSpd,varname:node_2569,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2,max:5;n:type:ShaderForge.SFN_Multiply,id:9404,x:32560,y:34837,varname:node_9404,prsc:2|A-2569-OUT,B-8236-T;n:type:ShaderForge.SFN_Slider,id:1725,x:32145,y:35350,ptovrint:False,ptlb:CloudSpinSpd,ptin:_CloudSpinSpd,varname:node_1725,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3,max:1;n:type:ShaderForge.SFN_Multiply,id:2350,x:32591,y:35208,varname:node_2350,prsc:2|A-8236-T,B-1725-OUT;n:type:ShaderForge.SFN_Panner,id:4434,x:32877,y:35148,varname:node_4434,prsc:2,spu:1,spv:0|UVIN-4878-UVOUT,DIST-2350-OUT;n:type:ShaderForge.SFN_Tex2d,id:5049,x:33054,y:35376,ptovrint:False,ptlb:Clouds Tex,ptin:_CloudsTex,varname:node_5049,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:af490265082fedd48ad69d269bbb935f,ntxv:0,isnm:False|UVIN-4434-UVOUT;n:type:ShaderForge.SFN_Set,id:7665,x:33665,y:35369,varname:Clouds,prsc:2|IN-7950-OUT;n:type:ShaderForge.SFN_Get,id:1030,x:34734,y:32816,varname:node_1030,prsc:2|IN-7665-OUT;n:type:ShaderForge.SFN_Add,id:9598,x:34952,y:32854,varname:node_9598,prsc:2|A-1030-OUT,B-9233-OUT;n:type:ShaderForge.SFN_Relay,id:9908,x:32428,y:33101,cmnt:Specular,varname:node_9908,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5918,x:32329,y:33215,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:2023,x:32329,y:33372,varname:node_2023,prsc:2;n:type:ShaderForge.SFN_Dot,id:8271,x:32591,y:33194,varname:node_8271,prsc:2,dt:1|A-5918-OUT,B-2023-OUT;n:type:ShaderForge.SFN_Slider,id:232,x:32496,y:33447,ptovrint:False,ptlb:SpecularPower,ptin:_SpecularPower,varname:node_232,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.619136,max:10;n:type:ShaderForge.SFN_Exp,id:7468,x:32861,y:33366,varname:node_7468,prsc:2,et:0|IN-232-OUT;n:type:ShaderForge.SFN_Power,id:4092,x:32873,y:33188,varname:node_4092,prsc:2|VAL-8271-OUT,EXP-7468-OUT;n:type:ShaderForge.SFN_Slider,id:1448,x:33038,y:33431,ptovrint:False,ptlb:SpecularIntensity,ptin:_SpecularIntensity,varname:node_1448,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.10145,max:2;n:type:ShaderForge.SFN_Color,id:9166,x:33032,y:33014,ptovrint:False,ptlb:SpecularColor,ptin:_SpecularColor,varname:node_9166,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4101,x:33129,y:33188,varname:node_4101,prsc:2|A-9166-RGB,B-4092-OUT,C-1448-OUT;n:type:ShaderForge.SFN_Set,id:7682,x:33535,y:33198,varname:SpecularData,prsc:2|IN-4433-OUT;n:type:ShaderForge.SFN_Add,id:4320,x:35384,y:32981,varname:node_4320,prsc:2|A-4163-OUT,B-924-OUT,C-5641-OUT,D-9397-OUT;n:type:ShaderForge.SFN_Get,id:9787,x:34952,y:33104,varname:node_9787,prsc:2|IN-7682-OUT;n:type:ShaderForge.SFN_Get,id:2947,x:33359,y:33324,varname:node_2947,prsc:2|IN-2528-OUT;n:type:ShaderForge.SFN_Multiply,id:4433,x:33359,y:33162,varname:node_4433,prsc:2|A-4101-OUT,B-2947-OUT;n:type:ShaderForge.SFN_Tex2d,id:3157,x:33166,y:34642,ptovrint:False,ptlb:EarthWater,ptin:_EarthWater,varname:node_3157,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0f6b4b1ebdc4aa24c84a2fc22672e230,ntxv:0,isnm:False|UVIN-5025-UVOUT;n:type:ShaderForge.SFN_Set,id:9832,x:33420,y:34662,varname:EarthWater,prsc:2|IN-3157-RGB;n:type:ShaderForge.SFN_Get,id:3539,x:34780,y:33220,varname:node_3539,prsc:2|IN-9832-OUT;n:type:ShaderForge.SFN_Multiply,id:924,x:35164,y:33053,varname:node_924,prsc:2|A-9787-OUT,B-5565-OUT;n:type:ShaderForge.SFN_OneMinus,id:5565,x:34988,y:33184,varname:node_5565,prsc:2|IN-3539-OUT;n:type:ShaderForge.SFN_Tex2d,id:798,x:32933,y:34522,ptovrint:False,ptlb:node_798,ptin:_node_798,varname:node_798,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d4c1223acb28b2045996285b17b78b55,ntxv:3,isnm:True|UVIN-5025-UVOUT;n:type:ShaderForge.SFN_Set,id:6399,x:33553,y:34522,varname:EarthNormalMap,prsc:2|IN-6193-OUT;n:type:ShaderForge.SFN_Get,id:6039,x:35367,y:32693,varname:node_6039,prsc:2|IN-6399-OUT;n:type:ShaderForge.SFN_Slider,id:7255,x:32991,y:34271,ptovrint:False,ptlb:NormalMapIntensity,ptin:_NormalMapIntensity,varname:node_7255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4796038,max:1;n:type:ShaderForge.SFN_Tex2d,id:4414,x:33166,y:35058,ptovrint:False,ptlb:node_4414,ptin:_node_4414,varname:node_4414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c8082f317668c0d4698635ec4484d3e7,ntxv:0,isnm:False|UVIN-5025-UVOUT;n:type:ShaderForge.SFN_Set,id:3393,x:34081,y:35014,varname:EarthLights,prsc:2|IN-3839-OUT;n:type:ShaderForge.SFN_Get,id:5501,x:33166,y:35222,varname:node_5501,prsc:2|IN-2528-OUT;n:type:ShaderForge.SFN_Multiply,id:3839,x:33794,y:35059,varname:node_3839,prsc:2|A-1497-RGB,B-4414-RGB,C-5620-OUT;n:type:ShaderForge.SFN_Get,id:5641,x:35164,y:33220,varname:node_5641,prsc:2|IN-3393-OUT;n:type:ShaderForge.SFN_OneMinus,id:5620,x:33520,y:35138,varname:node_5620,prsc:2|IN-5501-OUT;n:type:ShaderForge.SFN_Color,id:1497,x:33372,y:34935,ptovrint:False,ptlb:EarthLightsColor,ptin:_EarthLightsColor,varname:node_1497,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_AmbientLight,id:9091,x:34842,y:32643,varname:node_9091,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6740,x:35141,y:32757,varname:node_6740,prsc:2|A-9091-RGB,B-9598-OUT,C-8181-OUT;n:type:ShaderForge.SFN_Slider,id:8181,x:35062,y:32573,ptovrint:False,ptlb:EmissionIntensity,ptin:_EmissionIntensity,varname:node_8181,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4983755,max:1;n:type:ShaderForge.SFN_NormalVector,id:4399,x:32241,y:33719,prsc:2,pt:True;n:type:ShaderForge.SFN_Slider,id:506,x:32162,y:34005,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.312429,max:10;n:type:ShaderForge.SFN_Fresnel,id:2969,x:33037,y:33880,varname:node_2969,prsc:2|NRM-4399-OUT,EXP-506-OUT;n:type:ShaderForge.SFN_Set,id:9161,x:33146,y:33649,varname:FresnelData,prsc:2|IN-9156-OUT;n:type:ShaderForge.SFN_Get,id:944,x:35381,y:33439,varname:node_944,prsc:2|IN-9161-OUT;n:type:ShaderForge.SFN_ViewVector,id:6496,x:32241,y:33576,varname:node_6496,prsc:2;n:type:ShaderForge.SFN_Dot,id:6438,x:32483,y:33624,varname:node_6438,prsc:2,dt:1|A-6496-OUT,B-4399-OUT;n:type:ShaderForge.SFN_Exp,id:4929,x:32582,y:33850,varname:node_4929,prsc:2,et:0|IN-506-OUT;n:type:ShaderForge.SFN_Power,id:9156,x:32933,y:33649,varname:node_9156,prsc:2|VAL-6493-OUT,EXP-4929-OUT;n:type:ShaderForge.SFN_OneMinus,id:6493,x:32678,y:33634,varname:node_6493,prsc:2|IN-6438-OUT;n:type:ShaderForge.SFN_Get,id:4050,x:35217,y:33373,varname:node_4050,prsc:2|IN-2528-OUT;n:type:ShaderForge.SFN_Multiply,id:9397,x:35478,y:33197,varname:node_9397,prsc:2|A-4050-OUT,B-944-OUT;n:type:ShaderForge.SFN_Color,id:6883,x:33054,y:35555,ptovrint:False,ptlb:CloudColor,ptin:_CloudColor,varname:node_6883,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7950,x:33289,y:35375,varname:node_7950,prsc:2|A-5049-RGB,B-6883-RGB,C-4365-OUT;n:type:ShaderForge.SFN_Lerp,id:6193,x:33236,y:34426,varname:node_6193,prsc:2|A-1707-OUT,B-798-RGB,T-7255-OUT;n:type:ShaderForge.SFN_Vector3,id:1707,x:32933,y:34364,varname:node_1707,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Get,id:5807,x:33003,y:35758,varname:node_5807,prsc:2|IN-2528-OUT;n:type:ShaderForge.SFN_Power,id:4365,x:33305,y:35609,varname:node_4365,prsc:2|VAL-5807-OUT,EXP-2301-OUT;n:type:ShaderForge.SFN_Slider,id:4518,x:32867,y:35952,ptovrint:False,ptlb:CloudsShadowAtenuation,ptin:_CloudsShadowAtenuation,varname:node_4518,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:0,max:3;n:type:ShaderForge.SFN_Exp,id:2301,x:33199,y:35792,varname:node_2301,prsc:2,et:0|IN-4518-OUT;proporder:1426-2569-1725-5049-232-1448-9166-3157-798-7255-4414-1497-8181-506-6883-4518;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _EarthTex ("EarthTex", 2D) = "white" {}
        _EarthSpinSpd ("EarthSpinSpd", Range(0, 5)) = 0.2
        _CloudSpinSpd ("CloudSpinSpd", Range(0, 1)) = 0.3
        _CloudsTex ("Clouds Tex", 2D) = "white" {}
        _SpecularPower ("SpecularPower", Range(0, 10)) = 4.619136
        _SpecularIntensity ("SpecularIntensity", Range(0, 2)) = 1.10145
        _SpecularColor ("SpecularColor", Color) = (1,1,1,1)
        _EarthWater ("EarthWater", 2D) = "white" {}
        _node_798 ("node_798", 2D) = "bump" {}
        _NormalMapIntensity ("NormalMapIntensity", Range(0, 1)) = 0.4796038
        _node_4414 ("node_4414", 2D) = "white" {}
        _EarthLightsColor ("EarthLightsColor", Color) = (1,1,1,1)
        _EmissionIntensity ("EmissionIntensity", Range(0, 1)) = 0.4983755
        _FresnelPower ("FresnelPower", Range(0, 10)) = 2.312429
        _CloudColor ("CloudColor", Color) = (1,1,1,1)
        _CloudsShadowAtenuation ("CloudsShadowAtenuation", Range(-3, 3)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "CustomTag"="SF"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #if !UNITY_PASS_FORWARDBASE
            #define UNITY_PASS_FORWARDBASE
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _EarthTex; uniform float4 _EarthTex_ST;
            uniform float _EarthSpinSpd;
            uniform float _CloudSpinSpd;
            uniform sampler2D _CloudsTex; uniform float4 _CloudsTex_ST;
            uniform float _SpecularPower;
            uniform float _SpecularIntensity;
            uniform float4 _SpecularColor;
            uniform sampler2D _EarthWater; uniform float4 _EarthWater_ST;
            uniform sampler2D _node_798; uniform float4 _node_798_ST;
            uniform float _NormalMapIntensity;
            uniform sampler2D _node_4414; uniform float4 _node_4414_ST;
            uniform float4 _EarthLightsColor;
            uniform float _EmissionIntensity;
            uniform float _FresnelPower;
            uniform float4 _CloudColor;
            uniform float _CloudsShadowAtenuation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8236 = _Time;
                float2 node_5025 = (i.uv0+(_EarthSpinSpd*node_8236.g)*float2(1,0));
                float3 _node_798_var = UnpackNormal(tex2D(_node_798,TRANSFORM_TEX(node_5025, _node_798)));
                float3 EarthNormalMap = lerp(float3(0,0,1),_node_798_var.rgb,_NormalMapIntensity);
                float3 normalLocal = EarthNormalMap;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
////// Emissive:
                float2 node_4434 = (i.uv0+(node_8236.g*_CloudSpinSpd)*float2(1,0));
                float4 _CloudsTex_var = tex2D(_CloudsTex,TRANSFORM_TEX(node_4434, _CloudsTex));
                float node_7430 = (max(0,dot(lightDirection,normalDirection))*attenuation);
                float ShadowData = node_7430;
                float3 Clouds = (_CloudsTex_var.rgb*_CloudColor.rgb*pow(ShadowData,exp(_CloudsShadowAtenuation)));
                float4 _EarthTex_var = tex2D(_EarthTex,TRANSFORM_TEX(node_5025, _EarthTex));
                float3 EarthMain = _EarthTex_var.rgb;
                float3 node_9598 = (Clouds+EarthMain);
                float3 emissive = (UNITY_LIGHTMODEL_AMBIENT.rgb*node_9598*_EmissionIntensity);
                float3 LightData = (node_7430*_LightColor0.rgb);
                float3 SpecularData = ((_SpecularColor.rgb*pow(max(0,dot(normalDirection,halfDirection)),exp(_SpecularPower))*_SpecularIntensity)*ShadowData);
                float4 _EarthWater_var = tex2D(_EarthWater,TRANSFORM_TEX(node_5025, _EarthWater));
                float3 EarthWater = _EarthWater_var.rgb;
                float4 _node_4414_var = tex2D(_node_4414,TRANSFORM_TEX(node_5025, _node_4414));
                float node_5501 = ShadowData;
                float3 EarthLights = (_EarthLightsColor.rgb*_node_4414_var.rgb*(1.0 - node_5501));
                float node_6438 = max(0,dot(viewDirection,normalDirection));
                float FresnelData = pow((1.0 - node_6438),exp(_FresnelPower));
                float node_944 = FresnelData;
                float3 finalColor = emissive + ((node_9598*LightData)+(SpecularData*(1.0 - EarthWater))+EarthLights+(ShadowData*node_944));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #if !UNITY_PASS_FORWARDADD
            #define UNITY_PASS_FORWARDADD
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _EarthTex; uniform float4 _EarthTex_ST;
            uniform float _EarthSpinSpd;
            uniform float _CloudSpinSpd;
            uniform sampler2D _CloudsTex; uniform float4 _CloudsTex_ST;
            uniform float _SpecularPower;
            uniform float _SpecularIntensity;
            uniform float4 _SpecularColor;
            uniform sampler2D _EarthWater; uniform float4 _EarthWater_ST;
            uniform sampler2D _node_798; uniform float4 _node_798_ST;
            uniform float _NormalMapIntensity;
            uniform sampler2D _node_4414; uniform float4 _node_4414_ST;
            uniform float4 _EarthLightsColor;
            uniform float _EmissionIntensity;
            uniform float _FresnelPower;
            uniform float4 _CloudColor;
            uniform float _CloudsShadowAtenuation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8236 = _Time;
                float2 node_5025 = (i.uv0+(_EarthSpinSpd*node_8236.g)*float2(1,0));
                float3 _node_798_var = UnpackNormal(tex2D(_node_798,TRANSFORM_TEX(node_5025, _node_798)));
                float3 EarthNormalMap = lerp(float3(0,0,1),_node_798_var.rgb,_NormalMapIntensity);
                float3 normalLocal = EarthNormalMap;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float2 node_4434 = (i.uv0+(node_8236.g*_CloudSpinSpd)*float2(1,0));
                float4 _CloudsTex_var = tex2D(_CloudsTex,TRANSFORM_TEX(node_4434, _CloudsTex));
                float node_7430 = (max(0,dot(lightDirection,normalDirection))*attenuation);
                float ShadowData = node_7430;
                float3 Clouds = (_CloudsTex_var.rgb*_CloudColor.rgb*pow(ShadowData,exp(_CloudsShadowAtenuation)));
                float4 _EarthTex_var = tex2D(_EarthTex,TRANSFORM_TEX(node_5025, _EarthTex));
                float3 EarthMain = _EarthTex_var.rgb;
                float3 node_9598 = (Clouds+EarthMain);
                float3 LightData = (node_7430*_LightColor0.rgb);
                float3 SpecularData = ((_SpecularColor.rgb*pow(max(0,dot(normalDirection,halfDirection)),exp(_SpecularPower))*_SpecularIntensity)*ShadowData);
                float4 _EarthWater_var = tex2D(_EarthWater,TRANSFORM_TEX(node_5025, _EarthWater));
                float3 EarthWater = _EarthWater_var.rgb;
                float4 _node_4414_var = tex2D(_node_4414,TRANSFORM_TEX(node_5025, _node_4414));
                float node_5501 = ShadowData;
                float3 EarthLights = (_EarthLightsColor.rgb*_node_4414_var.rgb*(1.0 - node_5501));
                float node_6438 = max(0,dot(viewDirection,normalDirection));
                float FresnelData = pow((1.0 - node_6438),exp(_FresnelPower));
                float node_944 = FresnelData;
                float3 finalColor = ((node_9598*LightData)+(SpecularData*(1.0 - EarthWater))+EarthLights+(ShadowData*node_944));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
