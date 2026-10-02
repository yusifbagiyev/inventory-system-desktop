-- Fictional demo data. The passwords use the sample PasswordKey, so sign in as admin / Demo-Admin-2024 or operator / Demo-User-2024.
-- With a different PasswordKey these logins fail, so add the users again in the app under Users > Add.

INSERT INTO dbo.Category (catname) VALUES
 (N'Notebook'), (N'Monitor'), (N'Printer'), (N'Router'), (N'Switch'), (N'IP Telephone'), (N'Access Control'), (N'UPS');

INSERT INTO dbo.Department (dname, dhead, dcontact, ddesc) VALUES
 (N'IT Storage', N'Warehouse', N'-', N'Equipment not in use'),
 (N'Accounting', N'Head of Accounting', N'+994 00 000 00 01', N''),
 (N'Human Resources', N'HR Manager', N'+994 00 000 00 02', N''),
 (N'Marketing', N'Marketing Lead', N'+994 00 000 00 03', N''),
 (N'Call Center', N'Shift Supervisor', N'+994 00 000 00 04', N'');

INSERT INTO dbo.Product (prodCode, pcategory, pvendor, pmodel, pdepartment, pworker, pdescription) VALUES
 (N'1001', N'Notebook', N'Lenovo', N'ThinkPad E14', N'Accounting', N'Worker A', N''),
 (N'1002', N'Notebook', N'Dell', N'Latitude 5420', N'Marketing', N'Worker B', N''),
 (N'1003', N'Monitor', N'Dell', N'P2422H', N'Accounting', N'Worker A', N''),
 (N'1004', N'Monitor', N'Samsung', N'S24R350', N'Call Center', N'', N''),
 (N'1005', N'Printer', N'HP', N'LaserJet M404', N'Human Resources', N'', N''),
 (N'1006', N'Router', N'MikroTik', N'hEX S', N'IT Storage', N'', N'Spare'),
 (N'1007', N'Switch', N'TP-Link', N'TL-SG1016', N'Call Center', N'', N''),
 (N'1008', N'IP Telephone', N'Yealink', N'T31P', N'Call Center', N'Worker C', N''),
 (N'1009', N'Access Control', N'ZKTeco', N'SpeedFace V5L', N'IT Storage', N'', N''),
 (N'1010', N'UPS', N'APC', N'Back-UPS 650', N'Accounting', N'', N'');

INSERT INTO dbo.Route (prodCode, FrmDep, FrmWorker, ToDep, ToWorker, [Date], Description) VALUES
 (N'1001', N'IT Storage', N'', N'Accounting', N'Worker A', N'12.03.2024', N'New hire'),
 (N'1002', N'IT Storage', N'', N'Marketing', N'Worker B', N'02.04.2024', N''),
 (N'1003', N'IT Storage', N'', N'Accounting', N'Worker A', N'02.04.2024', N''),
 (N'1004', N'Marketing', N'', N'Call Center', N'', N'15.05.2024', N'Second screen'),
 (N'1006', N'Call Center', N'', N'IT Storage', N'', N'20.06.2024', N'Replaced'),
 (N'1008', N'IT Storage', N'', N'Call Center', N'Worker C', N'01.07.2024', N'');

INSERT INTO dbo.Users (fullname, [password], [type], online, suspended, [session], ip_address, [language]) VALUES
 (N'admin', N'QoIlvBZUK8jlv/W/OEuHUA==', N'Admin', N'offline', N'enabled', NULL, NULL, N'English'),
 (N'operator', N'3lj6DRRbNfVBQhmJjM/uKw==', N'User', N'offline', N'enabled', NULL, NULL, N'English');
