using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFX_RenderDepth : MonoBehaviour
{
    DepthTextureMode defaultMode;
    private Camera cam;
    void OnEnable()
    {


#if UNITY_2020_1_OR_NEWER
        UnityEngine.Rendering.RenderPipelineManager.beginCameraRendering += OnCustomCameraRender;
        Shader.EnableKeyword("USE_SCREEN_TO_WORLD_DEPTH");
#else
        cam = GetComponent<Camera>();
        defaultMode = cam.depthTextureMode;
        if (cam.renderingPath == RenderingPath.Forward)
        {
            cam.depthTextureMode |= DepthTextureMode.Depth;
        }
#endif
    }


#if UNITY_2020_1_OR_NEWER
    void OnCustomCameraRender(UnityEngine.Rendering.ScriptableRenderContext context, Camera renderedCamera)
    {
        var projToView = GL.GetGPUProjectionMatrix(renderedCamera.projectionMatrix, true).inverse;
        projToView[1, 1] *= -1;
        Shader.SetGlobalMatrix("KW_ViewToWorld", renderedCamera.cameraToWorldMatrix);
        Shader.SetGlobalMatrix("KW_ProjToView", projToView);
    }
#endif

    // Update is called once per frame
    void OnDisable()
    {

#if UNITY_2020_1_OR_NEWER
        UnityEngine.Rendering.RenderPipelineManager.beginCameraRendering -= OnCustomCameraRender;
        Shader.DisableKeyword("USE_SCREEN_TO_WORLD_DEPTH");
#else
        GetComponent<Camera>().depthTextureMode = defaultMode;
#endif

    }
}
