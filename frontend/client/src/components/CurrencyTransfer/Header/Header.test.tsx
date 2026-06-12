import { render, screen } from '@testing-library/react';
import { Header } from './Header';

describe('CurrencyTransfer Component', () => {
  const fromHeader = {
    value: 1,
    name: 'Polish zloty is'
  };
  const toHeader = {
    value: 0.99,
    name: 'Japanese yen'
  };

  it('отображает текст о курсн валют на текущий момент', () => {
    render(<Header from={fromHeader} to={toHeader} date={new Date()} />);

    expect(screen.getByText(/1 Polish zloty is/)).toBeTruthy();
    expect(screen.getByText(/0\.99 Japanese yen/)).toBeTruthy();
  });
});
