<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Home extends CI_Controller
{
	public function index()
	{
    if($this->check_session())
		{
      $session = $this->m_session->get_session();

      $data["title"] = "Dashboard";
      $data["page"] = "dashboard";
      $data["name_user"] = $session["name"];

			$this->load->view('header', $data);
      $this->load->view('home');
      $this->load->view('footer');
		}
		else
		{redirect('auth/index');}
	}

  private function check_session()
  {return $this->m_session->check_session();}
}
