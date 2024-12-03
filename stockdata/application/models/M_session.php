<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class m_session extends CI_Model
{
  public function get_session()
  {
    $ret = array(
      "user" => "",
      "token" => "",
			"name" => ""
    );

    $chkuser = $this->session->userdata('user');
    $chktoken = $this->session->userdata('token');
    $andises = $this->session->userdata('name');

    if($chkuser != NULL && $chktoken != NULL)
		{
      $ret["user"] = $chkuser;
      $ret["token"] = $chktoken;
      $ret["name"] = $andises;
    }

    return $ret;
  }

  public function check_session()
  {
    $ret = false;

    if($this->session->userdata('user') && $this->session->userdata('token'))
    {
      $fields = array(
        'username' => $this->session->userdata('user'),
        'token' => $this->session->userdata('token')
      );

      $ch = curl_init();
      curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__)."\localhost.crt");
      curl_setopt($ch, CURLOPT_URL, $this->m_constant->get_api_url().'user/getdata');
      curl_setopt($ch, CURLOPT_POST, 1);
      curl_setopt($ch, CURLOPT_HTTPHEADER, array("Content-type: application/json"));
      curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
      curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($fields));
      curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
      $result = curl_exec($ch);
      $http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);

      $json_data = json_decode($result, false);
      if($http_code == 200)
      {$ret = true;}
    }

    return $ret;
  }

	public function get_ip()
	{
		$ip = getenv('HTTP_CLIENT_IP')?:
			getenv('HTTP_X_FORWARDED_FOR')?:
			getenv('HTTP_X_FORWARDED')?:
			getenv('HTTP_FORWARDED_FOR')?:
			getenv('HTTP_FORWARDED')?:
			getenv('REMOTE_ADDR');

		return $ip;
	}
}