Public Class ClassBook

#Region "properties"

    Public Property BName() As String

        Get

            Return m_BName

        End Get

        Set(ByVal value As String)
            m_BName = value

        End Set

    End Property

    Private m_BName As String

    Public Property BPrice() As String
        Get

            Return m_BPrice

        End Get

        Set(ByVal value As String)
            m_BPrice = value

        End Set

    End Property

    Private m_BPrice As String

    Public Property BEdition() As String
        Get

            Return m_BEdition

        End Get

        Set(ByVal value As String)

            m_BEdition = value

        End Set

    End Property

    Private m_BEdition As String

    Public Property BISBN() As String
        Get

            Return m_BISBN

        End Get

        Set(ByVal value As String)

            m_BISBN = value

        End Set

    End Property

    Private m_BISBN As String

    Public Property publisher() As String

        Get

            Return m_publisher

        End Get

        Set(ByVal value As String)

            m_publisher = value

        End Set

    End Property

    Private m_publisher As String

#End Region

End Class


