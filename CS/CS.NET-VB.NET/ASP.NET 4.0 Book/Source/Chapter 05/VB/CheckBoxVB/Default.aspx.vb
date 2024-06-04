
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ListBox1.Items.Add(CheckBox1.Text)
        Else
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox1.Text))
        End If

    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            ListBox1.Items.Add(CheckBox2.Text)
        Else
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox2.Text))
        End If

    End Sub

    Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            ListBox1.Items.Add(CheckBox3.Text)
        Else
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox3.Text))
        End If

    End Sub

    Protected Sub CheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            ListBox1.Items.Add(CheckBox4.Text)
        Else
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox4.Text))
        End If

    End Sub

    Protected Sub CheckBox5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            ListBox1.Items.Add(CheckBox5.Text)
        Else
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox5.Text))
        End If

    End Sub
End Class
