<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Item extends CI_Controller
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
        $data["item"] = $json_data->model->multiform;
			}

      $ch = curl_init();
			curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'items/category');
			curl_setopt($ch, CURLOPT_HTTPHEADER, $header);
			curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
			$result = curl_exec($ch);
			$http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);
			curl_close($ch);
	
			if($result != False && $http_code != 500)
			{
				$json_data = json_decode($result, false);
        $data["category"] = $json_data->model->multiform;
			}

			$data["title"] = "Item Management";
			$data["page"] = "item";
			$data["name_user"] = $session["name"];

			$this->load->view('header', $data);
			$this->load->view('items');
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
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'items/category');
			curl_setopt($ch, CURLOPT_HTTPHEADER, $header);
			curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
			$result = curl_exec($ch);
			$http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);
			curl_close($ch);
	
			if($result != False && $http_code != 500)
			{
				$json_data = json_decode($result, false);
        $data["category"] = $json_data->model->multiform;
			}

      $data["title"] = "Item Management";
			$data["page"] = "item";
			$data["name_user"] = $session["name"];

      $this->load->view('header', $data);
			$this->load->view('item_input');
			$this->load->view('footer');
    }
    else
		{redirect('auth/index');}
  }

  public function save()
  {
    if($this->check_session())
		{
			$session = $this->m_session->get_session();

      $cfile = curl_file_create($_FILES['itemimage']['tmp_name'],$_FILES['itemimage']['type'],$_FILES['itemimage']['name']);

			$fields = array(
        'name' => $this->input->post('itemname'),
        'price' => $this->input->post('itemprice'),
        'stock' => $this->input->post('itememount'),
        'category' => $this->input->post('itemcategory'),
        'image' => $cfile
			);
      
			$header = array(
        "Content-Type: multipart/form-data",
				'username: '.$session["user"],
				'token: '.$session["token"]
			);
	
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
			curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'items');
      curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
			curl_setopt($ch, CURLOPT_HTTPHEADER, $header);
			curl_setopt($ch, CURLOPT_POST, 1);
			curl_setopt($ch, CURLOPT_POSTFIELDS, $fields);
			curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
			curl_setopt($ch, CURLOPT_HEADER, true);
			$result = curl_exec($ch);
			$http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);

			curl_close($ch);
	
			redirect("item");
		}
		else
		{redirect('auth/index');}
  }

  private function check_session()
  {return $this->m_session->check_session();}
}