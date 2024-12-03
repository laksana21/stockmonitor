<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Pos extends CI_Controller
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
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'pos/transaction');
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

			$data["title"] = "Point of Sales";
			$data["page"] = "pos";
			$data["name_user"] = $session["name"];
			$data["item"] = $json_data->model->multiform;

			$this->load->view('header', $data);
			$this->load->view('transaction');
			$this->load->view('footer');
		}
		else
		{redirect('auth/index');}
	}

	public function input()
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
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'items');
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
			
			$data["title"] = "Input Transaction";
			$data["page"] = "pos";
			$data["name_user"] = $session["name"];
			$data["item"] = $json_data->model->multiform;
	
			$this->load->view('header', $data);
			$this->load->view('transaction_input');
			$this->load->view('footer');
		}
		else
		{redirect('auth/index');}
	}

	public function submit()
	{
		if($this->check_session())
		{
			$session = $this->m_session->get_session();

			$fields = array(
				'Item_id' => $this->input->post('selectitem'),
				'Pcs' => $this->input->post('itememount')
			);
	
			$header = array(
				'username: '.$session["user"],
				'token: '.$session["token"]
			);
	
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'pos/transaction');
			curl_setopt($ch, CURLOPT_HTTPHEADER, $header);
			curl_setopt($ch, CURLOPT_POST, 1);
			curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($fields));
			curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
			$result = curl_exec($ch);
			$http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);

			curl_close($ch);
	
			redirect("pos");
		}
		else
		{redirect('auth/index');}
	}

	private function check_session()
  {return $this->m_session->check_session();}
}
