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
        <section className={`menu ${isOpen ? 'open' : ''}`}>
          <ul className={`nav-links`}>
            <li><Link to="/" onClick={() => setIsOpen(false)}>Home</Link></li>
            <li><Link to="/animals" onClick={() => setIsOpen(false)}>Animals</Link></li>
          </ul>
        </section>
      </nav>
    </header>
  );
};

export default Navbar;