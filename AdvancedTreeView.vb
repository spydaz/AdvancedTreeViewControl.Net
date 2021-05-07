Imports AdvTreeViewControl.SDK.AdvancedTreeViewNodes

Namespace SDK
    Public Class AdvancedTreeView
        Inherits TreeView
        Public Sub New()
            MyBase.New()
        End Sub

        Private m_CurrentComboBoxNode As ComboBoxNode = Nothing
        Private m_CurrentTextBoxNode As TextBoxNode = Nothing
        Private m_CurrentButtonNode As ButtonNode = Nothing
        Protected Overrides Sub OnNodeMouseClick(ByVal e As TreeNodeMouseClickEventArgs)
            If TypeOf e.Node Is ComboBoxNode Then
                Me.m_CurrentComboBoxNode = CType(e.Node, ComboBoxNode)
                Me.Controls.Add(Me.m_CurrentComboBoxNode.ComboBox)
                Me.m_CurrentComboBoxNode.ComboBox.SetBounds(Me.m_CurrentComboBoxNode.Bounds.X - 1, Me.m_CurrentComboBoxNode.Bounds.Y - 2, Me.m_CurrentComboBoxNode.Bounds.Width + 25, Me.m_CurrentComboBoxNode.Bounds.Height)
                AddHandler Me.m_CurrentComboBoxNode.ComboBox.SelectedValueChanged, New EventHandler(AddressOf ComboBox_SelectedValueChanged)
                AddHandler Me.m_CurrentComboBoxNode.ComboBox.DropDownClosed, New EventHandler(AddressOf ComboBox_DropDownClosed)
                Me.m_CurrentComboBoxNode.ComboBox.Show()
                Me.m_CurrentComboBoxNode.ComboBox.DroppedDown = True
            End If
            If TypeOf e.Node Is TextBoxNode Then
                Me.m_CurrentTextBoxNode = CType(e.Node, TextBoxNode)
                Me.Controls.Add(Me.m_CurrentTextBoxNode.TextBox)
                Me.m_CurrentTextBoxNode.TextBox.SetBounds(Me.m_CurrentTextBoxNode.Bounds.X - 1, Me.m_CurrentTextBoxNode.Bounds.Y - 2, Me.m_CurrentTextBoxNode.Bounds.Width + 25, Me.m_CurrentTextBoxNode.Bounds.Height)
                Me.m_CurrentTextBoxNode.TextBox.Show()
                ' AddHandler Me.m_CurrentTextBoxNode.TextBox.TextChanged, New EventHandler(AddressOf TextBox_TextChanged)
                ' Public Sub TextBox_TextChanged(sender As Object, e As EventArgs)
            End If
            If TypeOf e.Node Is ButtonNode Then
                Me.m_CurrentButtonNode = CType(e.Node, ButtonNode)
                Me.Controls.Add(Me.m_CurrentButtonNode.button)
                Me.m_CurrentButtonNode.Button.SetBounds(Me.m_CurrentButtonNode.Bounds.X - 1, Me.m_CurrentButtonNode.Bounds.Y - 2, Me.m_CurrentButtonNode.Bounds.Width + 25, Me.m_CurrentButtonNode.Bounds.Height)
                Me.m_CurrentButtonNode.Button.Show()
                ' AddHandler Me.m_CurrentTextBoxNode.TextBox.TextChanged, New EventHandler(AddressOf TextBox_TextChanged)
                ' Public Sub TextBox_TextChanged(sender As Object, e As EventArgs)
            End If
            MyBase.OnNodeMouseClick(e)
        End Sub

        Private Sub ComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            HideComboBox()
        End Sub

        Private Sub ComboBox_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs)
            HideComboBox()
        End Sub

        Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
            HideComboBox()
            MyBase.OnMouseWheel(e)
        End Sub

        Private Sub HideComboBox()
            If Me.m_CurrentComboBoxNode IsNot Nothing Then

                Me.m_CurrentComboBoxNode.Text = Me.m_CurrentComboBoxNode.ComboBox.Text
                Me.m_CurrentComboBoxNode.ComboBox.Hide()
                Me.m_CurrentComboBoxNode.ComboBox.DroppedDown = False
                Me.Controls.Remove(Me.m_CurrentComboBoxNode.ComboBox)
                Me.m_CurrentComboBoxNode = Nothing
            End If
        End Sub
    End Class
    Namespace AdvancedTreeViewNodes
        Public Enum AdvancedTreeViewNodeType
            ComboBox
            TextBox
            Button
        End Enum
        Public Class ComboBoxNode
            Inherits TreeNode
            Private m_ComboBox As ComboBox = New ComboBox()

            Public Sub New()
            End Sub

            Public Sub New(text As String)
                MyBase.New(text)
            End Sub

            Public Sub New(text As String, children() As TreeNode)
                MyBase.New(text, children)
            End Sub

            Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer)
                MyBase.New(text, imageIndex, selectedImageIndex)
            End Sub

            Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer, children() As TreeNode)
                MyBase.New(text, imageIndex, selectedImageIndex, children)
            End Sub

            Protected Sub New(serializationInfo As Runtime.Serialization.SerializationInfo, context As Runtime.Serialization.StreamingContext)
                MyBase.New(serializationInfo, context)
            End Sub

            Public ReadOnly Property Type As AdvancedTreeViewNodeType
                Get
                    Return AdvancedTreeViewNodeType.ComboBox
                End Get
            End Property

            Public Property ComboBox As ComboBox
                Get

                    Me.m_ComboBox.DropDownStyle = ComboBoxStyle.DropDown
                    Return Me.m_ComboBox
                End Get
                Set(ByVal value As ComboBox)
                    Me.m_ComboBox = value

                End Set
            End Property

        End Class
        Public Class TextBoxNode
            Inherits TreeNode
            Private m_ComboBox As TextBox = New TextBox()

            Public Sub New()
            End Sub

            Public Sub New(text As String)
                MyBase.New()
                TextBox.Text = text
            End Sub

            Public Sub New(text As String, children() As TreeNode)
                MyBase.New("", children)
                TextBox.Text = text
            End Sub

            Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer)
                MyBase.New("", imageIndex, selectedImageIndex)
                TextBox.Text = text
            End Sub

            Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer, children() As TreeNode)
                MyBase.New("", imageIndex, selectedImageIndex, children)
                TextBox.Text = text
            End Sub

            Protected Sub New(serializationInfo As Runtime.Serialization.SerializationInfo, context As Runtime.Serialization.StreamingContext)
                MyBase.New(serializationInfo, context)
            End Sub

            Public ReadOnly Property Type As AdvancedTreeViewNodeType
                Get
                    Return AdvancedTreeViewNodeType.TextBox
                End Get
            End Property

            Public Property TextBox As TextBox
                Get


                    Return Me.m_ComboBox
                End Get
                Set(ByVal value As TextBox)
                    Me.m_ComboBox = value

                End Set
            End Property

        End Class
        ''' <summary>
        ''' Still need work to map the button press handling
        ''' </summary>
        Public Class ButtonNode
            Inherits TreeNode
            Private m_ComboBox As Button = New Button()

            Public Sub New()
            End Sub

            Public Sub New(text As String)
                MyBase.New()
                Button.Text = text
            End Sub

            Public Sub New(text As String, children() As TreeNode)
                MyBase.New("", children)
                Button.Text = text
            End Sub

            Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer)
                MyBase.New("", imageIndex, selectedImageIndex)
                Button.Text = text
            End Sub

            Public Sub New(text As String, imageIndex As Integer, selectedImageIndex As Integer, children() As TreeNode)
                MyBase.New("", imageIndex, selectedImageIndex, children)
                Button.Text = text
            End Sub

            Protected Sub New(serializationInfo As Runtime.Serialization.SerializationInfo, context As Runtime.Serialization.StreamingContext)
                MyBase.New(serializationInfo, context)
            End Sub

            Public ReadOnly Property Type As AdvancedTreeViewNodeType
                Get
                    Return AdvancedTreeViewNodeType.Button
                End Get
            End Property

            Public Property Button As Button
                Get


                    Return Me.m_ComboBox
                End Get
                Set(ByVal value As Button)
                    Me.m_ComboBox = value

                End Set
            End Property

        End Class
    End Namespace
End Namespace

