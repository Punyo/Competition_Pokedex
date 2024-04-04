using UnityEngine;

public class RenderTextureClickPosition : MonoBehaviour
{
    public Camera renderTextureCamera; // RenderTextureを表示するカメラ
    public RenderTexture renderTexture; // 対象のRenderTexture

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウス左クリックが押されたとき
        {
            // マウスのスクリーン座標を取得
            Vector3 mousePosition = Input.mousePosition;

            // スクリーン座標をRenderTexture内の座標に変換
            Vector3 renderTextureMousePosition = GetRenderTextureMousePosition(mousePosition);

            // RenderTexture上でのクリック位置を表示
            Debug.Log("RenderTexture上でのクリック位置：" + renderTextureMousePosition);
        }
    }

    // スクリーン座標をRenderTexture内の座標に変換する関数
    private Vector3 GetRenderTextureMousePosition(Vector3 screenPosition)
    {
        // スクリーン座標をViewport座標に変換
        Vector3 viewportPosition = renderTextureCamera.ScreenToViewportPoint(screenPosition);

        // Viewport座標をRenderTexture内の座標に変換
        Vector3 renderTexturePosition = new Vector3(
            viewportPosition.x * renderTexture.width,
            viewportPosition.y * renderTexture.height,
            0
        );

        return renderTexturePosition;
    }
}