<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Auth extends CI_Controller
{
	public function index()
	{
    if($this->check_session())
		{redirect('home');}
		else
		{
      $this->session->sess_destroy();
      $this->load->view('login');
    }
	}

  public function login()
  {
    $fields = array(
      'username' => $this->input->post('loginUser'),
      'password' => $this->input->post('loginPassword')
    );

    $ch = curl_init();
    curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
    curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'login');
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_HTTPHEADER, array("Content-type: application/json"));
    curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
    curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($fields));
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    $result = curl_exec($ch);
    $http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);

    // if ($result === false) {
    //   throw new Exception(curl_error($ch), curl_errno($ch));
    // }

    if($result != False && $http_code != 500)
    {
      $json_data = json_decode($result, false);
      if($http_code == 200)
      {
        $data_session = array(
          'user' => $json_data->model->username,
          'name' => $json_data->model->name,
          'token' => $json_data->model->token
        );
        $this->session->set_userdata($data_session);

        redirect('home');
      }
      else
      {redirect('auth');}
    }
    else
    {redirect('auth');}

    curl_close($ch);
  }

  public function logout()
  {
    $session = $this->m_session->get_session();
    
    $fields = array(
      'username' => $session["user"],
      'token' => $session["token"]
    );

    $ch = curl_init();
    curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
    curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'logout');
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_HTTPHEADER, array("Content-type: application/json"));
    curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
    curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($fields));
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    $result = curl_exec($ch);
    $http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);

    // if ($result === false) {
    //   throw new Exception(curl_error($ch), curl_errno($ch));
    // }

    if($result != False && $http_code != 500)
    {
      $json_data = json_decode($result, false);
      $this->session->sess_destroy();
      redirect('auth');
    }
    else
    {redirect('auth');}

    curl_close($ch);
  }

  private function check_session()
  {return $this->m_session->check_session();}
}
