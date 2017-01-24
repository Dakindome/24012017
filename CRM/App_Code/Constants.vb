Namespace CRM

Public Class Constants

  ' Fix this up to match your own path.
'  Private Const DataPath As String = "D:\Program Files\Office2000\Office\Samples\Northwind.mdb"
 ' Public Shared ReadOnly OleDbConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DataPath
 
        Public Shared ReadOnly OCN_MEDSD As String = "DSN=CRM_"
   Public Shared ReadOnly SCN_SQL3 As String = "packet size=4096;user id=osa;data source=svh-sql3;persist security info=True;initial catalog=medtrak_data;password=osa"
    Public Shared ReadOnly SCN_SQL As String = "packet size=4096;user id=sa;data source=svh-sql;persist security info=False;initial catalog=medtrak_data"
    Public Shared ReadOnly SCN_SQL21 As String = "packet size=4096;user id=osa2;data source=svh21-chk;persist security info=True;initial catalog=medtrak_data;password=osa2;connect timeout=600"
    Public Shared ReadOnly SCN_SQL24 As String = "Server=svh24-sql;uid=osa2;pwd=osa2;database=medtrak_data"
    'Public Shared ReadOnly SCN_SQL As String = "packet size=4096;user id=sa;data source=localhost ;persist security info=True;initial catalog=medtrak_data;password=sa"
    'Public Shared ReadOnly SCN_SQL3 As String = "packet size=4096;user id=sa;data source=localhost;persist security info=True;initial catalog=medtrak_data;password=sa"
    'Public Shared ReadOnly SCN_SQL21 As String = "packet size=4096;user id=sa;data source=localhost;persist security info=True;initial catalog=medtrak_data;password=sa;connect timeout=600"


End Class

End Namespace
