from cortex import Cortex
import time
import os
# print(os.path)
# f = open("Recordings/demofile3.txt", "w")
# f.write("Woops! I have deleted the content!")
# f.close()
class Record():
	def __init__(self):
		self.c = Cortex(user, debug_mode=True)
		self.c.do_prepare_steps()

	def create_record_then_export(self,
								record_name,
								record_description,
								record_length_s,
								record_export_folder,
								record_export_data_types,
								record_export_format,
								record_export_version):
		
		self.c.create_record(record_name,
							record_description)

		self.wait(record_length_s)

		self.c.stop_record()

		self.c.disconnect_headset()

		self.c.export_record(record_export_folder,
							record_export_data_types,
							record_export_format,
							record_export_version,
							[self.c.record_id])


	def wait(self, record_length_s):
		print('start recording -------------------------')
		length = 0
		while length < record_length_s:
			print('recording at {0} s'.format(length))
			time.sleep(1)
			length+=1
		print('end recording -------------------------')

# -----------------------------------------------------------
# 
# SETTING
# 	- replace your license, client_id, client_secret to user dic
# 	- specify infor for record and export
# 	- connect your headset with dongle or bluetooth, you should saw headset on EmotivApp
#
# RESULT
# 	- export result should be csv or edf file at location you specified
# 	- in that file will has data you specified like : eeg, motion, performance metric and band power
# 
# -----------------------------------------------------------

user = {
	"license" : "892df88d-fba1-47d9-922e-4cd9236e4940",
	"client_id" : "207ITaQgyyX7LDhuFfk45y8sOww7GwAVv7kqOnnd",
	"client_secret" : "RwADDtaifuO8gu9PJOnGVDZDmmEursNKqHy5dxVVgI1rDltlkl1uphyKb6L8gEs5FmpyxwObZedD70gvBvSuKVYr5j1A3kxxeimCIZoidWNpjBeqEn7KSoJ7qw9yTF0Q",
	"debit" : 100
}

r = Record()

# record parameters
record_name = 'baurami'
record_description = 'BLABLABLA'
record_length_s = 5


# export parameters
record_export_folder = '/tmp/csv2'
record_export_data_types = ['EEG']
record_export_format = 'CSV'
record_export_version = 'V2'


# start record --> stop record --> disconnect headset --> export record
r.create_record_then_export(record_name,
							record_description,
							record_length_s,
							record_export_folder,
							record_export_data_types,
							record_export_format,
							record_export_version )
# -----------------------------------------------------------
