<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Report extends CI_Controller
{
  public function index()
	{
		if($this->check_session())
		{
			$session = $this->m_session->get_session();
			$header = array(
				'username: '.$session["user"],
				'token: '.$session["token"]
			);

			$ch = curl_init();
			curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'pos/reports');
			curl_setopt($ch, CURLOPT_HTTPHEADER, $header);
			curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
			$result = curl_exec($ch);
			$http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);
			curl_close($ch);
	
			if($result != False && $http_code != 500)
			{
				$json_data = json_decode($result, false);
			}

			$data["title"] = "POS Report";
			$data["page"] = "report";
			$data["name_user"] = $session["name"];
			$data["item"] = $json_data->model->multiform;

			$this->load->view('header', $data);
			$this->load->view('transaction_report');
			$this->load->view('footer');
		}
		else
		{redirect('auth/index');}
	}

  private function check_session()
  {return $this->m_session->check_session();}
}