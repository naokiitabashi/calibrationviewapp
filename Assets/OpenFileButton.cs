using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Windows.Forms; //OpenFileDialog�p�Ɏg��


public class OpenFileButton : MonoBehaviour
{

    public void OpenExistFile()
    {

        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //�_�C�A���O���J��
        open_file_dialog.ShowDialog();

        //�擾�����t�@�C������string�ɑ������
        string file_name = open_file_dialog.FileName;

    }

}