import { render, screen, fireEvent } from '@testing-library/react';
import { CurrencySelect } from './CurrencySelect';
import { vi } from 'vitest';

describe('CurrencySelect Component', () => {
  const mockOnSelect = vi.fn();
  const selectedCurrency = 'PLN';

  it('отображает select с выбранной валютой и списком других вариантов', () => {
    render(<CurrencySelect selectedCurrency={selectedCurrency} onSelect={mockOnSelect} testId="currency-select" />);

    const select = screen.getByTestId('currency-select');
    expect(select).toBeInTheDocument();
    expect(select).toHaveValue('PLN');

    expect(screen.getByTestId('currency-option-CAD')).toBeInTheDocument();
    expect(screen.getByTestId('currency-option-PLN')).toBeInTheDocument();
    expect(screen.getByTestId('currency-option-AUD')).toBeInTheDocument();
    expect(screen.getByTestId('currency-option-JPY')).toBeInTheDocument();
    expect(screen.getByTestId('currency-option-ZAR')).toBeInTheDocument();
  });

  it('вызывает onSelect с новым значением при выборе валюты', () => {
    render(<CurrencySelect selectedCurrency={selectedCurrency} onSelect={mockOnSelect} testId="currency-select" />);

    const select = screen.getByTestId('currency-select');
    fireEvent.change(select, { target: { value: 'JPY' } });

    expect(mockOnSelect).toHaveBeenCalledTimes(1);
    expect(mockOnSelect).toHaveBeenCalledWith('JPY');
  });

  it('выбранная валюта отображается как selected', () => {
    render(<CurrencySelect selectedCurrency="JPY" onSelect={mockOnSelect} testId="currency-select" />);

    const select = screen.getByTestId('currency-select');

    expect(select).toHaveValue('JPY');
  });

  it('при изменении валюты значение в select обновляется', () => {
    const { rerender } = render(
      <CurrencySelect selectedCurrency="PLN" onSelect={mockOnSelect} testId="currency-select" />
    );

    const select = screen.getByTestId('currency-select');
    rerender(<CurrencySelect selectedCurrency="CAD" onSelect={mockOnSelect} testId="currency-select" />);

    expect(select).toHaveValue('CAD');
  });
});
