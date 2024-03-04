import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './Navbar.css'; // Make sure to create this CSS file

const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

  return (
    <header>
      <nav>
        <div className="hamburger" onClick={toggle}>
          &#9776;
        </div>
        <ul className={`nav-links ${isOpen ? 'open' : ''}`}>
          <li><Link to="/" onClick={() => setIsOpen(false)}>Home</Link></li>
          <li><Link to="/animals" onClick={() => setIsOpen(false)}>Animals</Link></li>
        </ul>
      </nav>
    </header>
  );
};

export default Navbar;