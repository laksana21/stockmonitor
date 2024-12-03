<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class m_constant extends CI_Model
{
  public function get_api_url()
  {
    $url = "https://localhost:7147/";

    return $url;
  }
}