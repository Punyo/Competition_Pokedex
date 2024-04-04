using UnityEngine;

public class RenderTextureClickPosition : MonoBehaviour
{
    public Camera renderTextureCamera; // RenderTexture��\������J����
    public RenderTexture renderTexture; // �Ώۂ�RenderTexture

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �}�E�X���N���b�N�������ꂽ�Ƃ�
        {
            // �}�E�X�̃X�N���[�����W���擾
            Vector3 mousePosition = Input.mousePosition;

            // �X�N���[�����W��RenderTexture���̍��W�ɕϊ�
            Vector3 renderTextureMousePosition = GetRenderTextureMousePosition(mousePosition);

            // RenderTexture��ł̃N���b�N�ʒu��\��
            Debug.Log("RenderTexture��ł̃N���b�N�ʒu�F" + renderTextureMousePosition);
        }
    }

    // �X�N���[�����W��RenderTexture���̍��W�ɕϊ�����֐�
    private Vector3 GetRenderTextureMousePosition(Vector3 screenPosition)
    {
        // �X�N���[�����W��Viewport���W�ɕϊ�
        Vector3 viewportPosition = renderTextureCamera.ScreenToViewportPoint(screenPosition);

        // Viewport���W��RenderTexture���̍��W�ɕϊ�
        Vector3 renderTexturePosition = new Vector3(
            viewportPosition.x * renderTexture.width,
            viewportPosition.y * renderTexture.height,
            0
        );

        return renderTexturePosition;
    }
}