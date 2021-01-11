private void BtnSelectFile_Click(object sender, EventArgs e)
{
	var ofd = new OpenFileDialog();
	txtFilePath.Text = 
	ofd.ShowDialog() == DialogResult.OK
	? ofd.FileName
	: null;
}